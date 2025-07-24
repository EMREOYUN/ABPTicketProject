using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Collections.Generic;

namespace ABPTicketProject.Events;

public interface IEventAppService : ICrudAppService<
        EventDto, // Used to show events
        Guid, // Primary key of the entity
        PagedAndSortedResultRequestDto, // Used for paging and sorting
        CreateUpdateEventDto> // Used to create and update events
{
    Task<PagedResultDto<EventDto>> GetSellerEventsAsync(PagedAndSortedResultRequestDto input);
    Task PurchaseTicketAsync(Guid eventId, int quantity);
    Task<List<PurchasedTicketDto>> GetMyPurchasedTicketsAsync();

    // Favorite events
    Task AddFavoriteAsync(Guid eventId);
    Task RemoveFavoriteAsync(Guid eventId);
    Task<bool> IsFavoriteAsync(Guid eventId);
    Task<List<EventDto>> GetMyFavoriteEventsAsync();
    Task<List<SellerEventPurchaseInfoDto>> GetSellerEventPurchaseInfoAsync();
}
