using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace ABPTicketProject.MongoDB;

[DependsOn(
    typeof(ABPTicketProjectApplicationTestModule),
    typeof(ABPTicketProjectMongoDbModule)
)]
public class ABPTicketProjectMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = ABPTicketProjectMongoDbFixture.GetRandomConnectionString();
        });
    }
}
