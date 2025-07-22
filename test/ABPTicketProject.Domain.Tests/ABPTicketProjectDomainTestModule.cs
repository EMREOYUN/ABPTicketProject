using Volo.Abp.Modularity;

namespace ABPTicketProject;

[DependsOn(
    typeof(ABPTicketProjectDomainModule),
    typeof(ABPTicketProjectTestBaseModule)
)]
public class ABPTicketProjectDomainTestModule : AbpModule
{

}
