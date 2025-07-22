using System;
using Volo.Abp.Application.Dtos;

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