using ABPTicketProject.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ABPTicketProject.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ABPTicketProjectMongoDbModule),
    typeof(ABPTicketProjectApplicationContractsModule)
)]
public class ABPTicketProjectDbMigratorModule : AbpModule
{
}
