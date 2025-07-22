using Volo.Abp.Data;
using Volo.Abp.MongoDB;
using MongoDB.Driver;

namespace ABPTicketProject.MongoDB;

[ConnectionStringName("Default")]
public class ABPTicketProjectMongoDbContext : AbpMongoDbContext
{
    public IMongoCollection<ABPTicketProject.Events.Event> Events => Collection<ABPTicketProject.Events.Event>();
    public IMongoCollection<ABPTicketProject.Events.PurchasedTicket> PurchasedTickets => Collection<ABPTicketProject.Events.PurchasedTicket>();
    public IMongoCollection<ABPTicketProject.Events.UserEventQuota> UserEventQuotas => Collection<ABPTicketProject.Events.UserEventQuota>();
    public IMongoCollection<ABPTicketProject.Events.FavoriteEvent> FavoriteEvents => Collection<ABPTicketProject.Events.FavoriteEvent>();

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        //builder.Entity<YourEntity>(b =>
        //{
        //    //...
        //});
    }
}
