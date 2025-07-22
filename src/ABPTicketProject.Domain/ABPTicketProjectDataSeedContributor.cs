using System;
using System.Threading.Tasks;
using ABPTicketProject.Events;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;


namespace ABPTicketProject;

public class ABPTicketProjectDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Events.Event, Guid> _eventRepository;
    public ABPTicketProjectDataSeedContributor(
        IRepository<Events.Event, Guid> eventRepository)
    {
        _eventRepository = eventRepository;
    }
    public async Task SeedAsync(DataSeedContext context)
    {
        
    }
}