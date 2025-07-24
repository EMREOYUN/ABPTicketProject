using System;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;

namespace ABPTicketProject.Events;

public class PurchasedTicketDto : EntityDto<Guid>
{
    public Guid UserId { get; set; }
    public Guid EventId { get; set; }
    public int Quantity { get; set; }
    public DateTime PurchaseDate { get; set; }
}

public class FavoriteEventDto : EntityDto<Guid>
{
    public Guid UserId { get; set; }
    public Guid EventId { get; set; }
}

public class SellerEventPurchaseInfoDto
{
    public Guid EventId { get; set; }
    public string EventName { get; set; }
    public int UniquePurchaserCount { get; set; }
    public List<PurchaserInfoDto> Purchasers { get; set; } = new();
}

public class PurchaserInfoDto
{
    public Guid UserId { get; set; }
    public string FullName { get; set; }
    public List<Guid> TicketIds { get; set; } = new();
}