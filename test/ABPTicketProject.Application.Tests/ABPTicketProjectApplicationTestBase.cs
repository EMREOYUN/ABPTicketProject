using Volo.Abp.Modularity;

namespace ABPTicketProject;

public abstract class ABPTicketProjectApplicationTestBase<TStartupModule> : ABPTicketProjectTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
