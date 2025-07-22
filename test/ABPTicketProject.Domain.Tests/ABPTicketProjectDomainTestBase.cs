using Volo.Abp.Modularity;

namespace ABPTicketProject;

/* Inherit from this class for your domain layer tests. */
public abstract class ABPTicketProjectDomainTestBase<TStartupModule> : ABPTicketProjectTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
