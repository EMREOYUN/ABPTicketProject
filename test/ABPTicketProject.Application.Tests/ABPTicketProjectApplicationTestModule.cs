using Volo.Abp.Modularity;

namespace ABPTicketProject;

[DependsOn(
    typeof(ABPTicketProjectApplicationModule),
    typeof(ABPTicketProjectDomainTestModule)
)]
public class ABPTicketProjectApplicationTestModule : AbpModule
{

}
