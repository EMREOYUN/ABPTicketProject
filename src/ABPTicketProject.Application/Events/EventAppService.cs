using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABPTicketProject.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;
using Volo.Abp.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ABPTicketProject.Events;

public class EventAppService : CrudAppService<Event, EventDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEventDto>, IEventAppService
{
    private readonly IRepository<PurchasedTicket, Guid> _purchasedTicketRepository;
    private readonly IRepository<UserEventQuota, Guid> _userEventQuotaRepository;
    private readonly IRepository<FavoriteEvent, Guid> _favoriteEventRepository;
    private readonly IIdentityUserRepository _identityUserRepository;

    public EventAppService(
        IRepository<Event, Guid> repository,
        IRepository<PurchasedTicket, Guid> purchasedTicketRepository,
        IRepository<UserEventQuota, Guid> userEventQuotaRepository,
        IRepository<FavoriteEvent, Guid> favoriteEventRepository,
        IIdentityUserRepository identityUserRepository)
        : base(repository)
    {
        _purchasedTicketRepository = purchasedTicketRepository;
        _userEventQuotaRepository = userEventQuotaRepository;
        _favoriteEventRepository = favoriteEventRepository;
        _identityUserRepository = identityUserRepository;
        GetPolicyName = ABPTicketProjectPermissions.SeeEvents;
        GetListPolicyName = ABPTicketProjectPermissions.SeeEvents;
        CreatePolicyName = ABPTicketProjectPermissions.CreateEvent;
        UpdatePolicyName = ABPTicketProjectPermissions.EditEvent;
        DeletePolicyName = ABPTicketProjectPermissions.DeleteEvent;
    }

    public override async Task<PagedResultDto<EventDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var queryable = await Repository.GetQueryableAsync();
        var now = DateTime.UtcNow;
        var filtered = queryable.Where(e => (e.active && e.date >= now));

        var totalCount = await AsyncExecuter.CountAsync(filtered);
        var items = await AsyncExecuter.ToListAsync(
            ApplySorting(
                ApplyPaging(filtered, input),
                input
            )
        );

        return new PagedResultDto<EventDto>(
            totalCount,
            items.Select(MapToGetListOutputDto).ToList()
        );
    }

    public async Task<PagedResultDto<EventDto>> GetSellerEventsAsync(PagedAndSortedResultRequestDto input)
    {
        var queryable = await Repository.GetQueryableAsync();
        var currentUserId = CurrentUser.Id;

        var filtered = queryable.Where(e => e.CreatorId == currentUserId && e.active);

        var totalCount = await AsyncExecuter.CountAsync(filtered);
        var items = await AsyncExecuter.ToListAsync(
            ApplySorting(
                ApplyPaging(filtered, input),
                input
            )
        );

        return new PagedResultDto<EventDto>(
            totalCount,
            items.Select(MapToGetListOutputDto).ToList()
        );
    }

    public async Task PurchaseTicketAsync(Guid eventId, int quantity)
    {
        if (quantity < 1)
            throw new UserFriendlyException("Quantity must be at least 1.");
        var userId = CurrentUser.Id ?? throw new UserFriendlyException("User is not logged in.");
        // Check purchase permission using ABP Permissions
        if (!await AuthorizationService.IsGrantedAsync(ABPTicketProjectPermissions.PurchaseTickets))
            throw new UserFriendlyException("You do not have permission to purchase tickets.");
        var @event = await Repository.GetAsync(eventId);
        if (!@event.active)
            throw new UserFriendlyException("Event is not active.");
        if (@event.date < DateTime.UtcNow)
            throw new UserFriendlyException("Event has already occurred.");
        if (@event.quota < quantity)
            throw new UserFriendlyException("Not enough tickets available.");
        // Get or create user quota
        var userQuota = (await _userEventQuotaRepository.GetQueryableAsync())
            .FirstOrDefault(q => q.UserId == userId && q.EventId == eventId);
        int alreadyPurchased = userQuota?.TicketsPurchased ?? 0;
        if (alreadyPurchased + quantity > @event.userQuota)
            throw new UserFriendlyException($"You can only purchase up to {@event.userQuota} tickets for this event.");
        // Update event quota
        @event.quota -= quantity;
        await Repository.UpdateAsync(@event);
        // Update or create user quota
        if (userQuota == null)
        {
            userQuota = new UserEventQuota
            {
                UserId = userId,
                EventId = eventId,
                TicketsPurchased = quantity
            };
            await _userEventQuotaRepository.InsertAsync(userQuota);
        }
        else
        {
            userQuota.TicketsPurchased += quantity;
            await _userEventQuotaRepository.UpdateAsync(userQuota);
        }
        // Store purchase
        var purchase = new PurchasedTicket
        {
            UserId = userId,
            EventId = eventId,
            Quantity = quantity,
            PurchaseDate = DateTime.UtcNow
        };
        await _purchasedTicketRepository.InsertAsync(purchase);
    }

    public async Task<List<PurchasedTicketDto>> GetMyPurchasedTicketsAsync()
    {
        var userId = CurrentUser.Id ?? throw new UserFriendlyException("User is not logged in.");
        var tickets = (await _purchasedTicketRepository.GetQueryableAsync())
            .Where(t => t.UserId == userId)
            .ToList();
        return ObjectMapper.Map<System.Collections.Generic.List<PurchasedTicket>, System.Collections.Generic.List<PurchasedTicketDto>>(tickets);
    }

    // Favorite events functionality
    public async Task AddFavoriteAsync(Guid eventId)
    {
        var userId = CurrentUser.Id ?? throw new UserFriendlyException("User is not logged in.");
        var exists = (await _favoriteEventRepository.GetQueryableAsync())
            .Any(f => f.UserId == userId && f.EventId == eventId);
        if (!exists)
        {
            await _favoriteEventRepository.InsertAsync(new FavoriteEvent { UserId = userId, EventId = eventId });
        }
    }

    public async Task RemoveFavoriteAsync(Guid eventId)
    {
        var userId = CurrentUser.Id ?? throw new UserFriendlyException("User is not logged in.");
        var favorite = (await _favoriteEventRepository.GetQueryableAsync())
            .FirstOrDefault(f => f.UserId == userId && f.EventId == eventId);
        if (favorite != null)
        {
            await _favoriteEventRepository.DeleteAsync(favorite);
        }
    }

    public async Task<bool> IsFavoriteAsync(Guid eventId)
    {
        var userId = CurrentUser.Id ?? throw new UserFriendlyException("User is not logged in.");
        return (await _favoriteEventRepository.GetQueryableAsync())
            .Any(f => f.UserId == userId && f.EventId == eventId);
    }

    public async Task<List<EventDto>> GetMyFavoriteEventsAsync()
    {
        var userId = CurrentUser.Id ?? throw new UserFriendlyException("User is not logged in.");
        var favoriteEventIds = (await _favoriteEventRepository.GetQueryableAsync())
            .Where(f => f.UserId == userId)
            .Select(f => f.EventId)
            .ToList();
        var events = (await Repository.GetQueryableAsync())
            .Where(e => favoriteEventIds.Contains(e.Id))
            .ToList();
        return ObjectMapper.Map<List<Event>, List<EventDto>>(events);
    }

    public async Task<List<SellerEventPurchaseInfoDto>> GetSellerEventPurchaseInfoAsync()
    {
        var sellerId = CurrentUser.Id ?? throw new UserFriendlyException("User is not logged in.");
        var events = (await Repository.GetQueryableAsync())
            .Where(e => e.CreatorId == sellerId)
            .ToList();
        var allTickets = (await _purchasedTicketRepository.GetQueryableAsync()).ToList();
        var purchaserIds = allTickets.Select(t => t.UserId).Distinct().ToList();
        var users = await _identityUserRepository.GetListAsync();
        var userDict = users.Where(u => purchaserIds.Contains(u.Id)).ToDictionary(u => u.Id, u => $"{u.Name} {u.Surname}".Trim());
        var result = new List<SellerEventPurchaseInfoDto>();
        foreach (var ev in events)
        {
            var ticketsForEvent = allTickets.Where(t => t.EventId == ev.Id).ToList();
            var purchasers = ticketsForEvent
                .GroupBy(t => t.UserId)
                .Select(g => new PurchaserInfoDto
                {
                    UserId = g.Key,
                    FullName = userDict.ContainsKey(g.Key) ? userDict[g.Key] : "Unknown",
                    TicketIds = g.Select(t => t.Id).ToList()
                }).ToList();
            result.Add(new SellerEventPurchaseInfoDto
            {
                EventId = ev.Id,
                EventName = ev.name,
                UniquePurchaserCount = purchasers.Count,
                Purchasers = purchasers
            });
        }
        return result;
    }
}