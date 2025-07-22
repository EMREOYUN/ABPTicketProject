using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace ABPTicketProject.Events
{
    public class PurchasedTicket : AuditedAggregateRoot<Guid>
    {
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
    }

    public class UserEventQuota : AuditedAggregateRoot<Guid>
    {
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        public int TicketsPurchased { get; set; }
    }

    public class FavoriteEvent : AuditedAggregateRoot<Guid>
    {
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
    }
}
