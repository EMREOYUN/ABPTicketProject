using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ABPTicketProject.Data;

/* This is used if database provider does't define
 * IABPTicketProjectDbSchemaMigrator implementation.
 */
public class NullABPTicketProjectDbSchemaMigrator : IABPTicketProjectDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
