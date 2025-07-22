using System.Threading.Tasks;

namespace ABPTicketProject.Data;

public interface IABPTicketProjectDbSchemaMigrator
{
    Task MigrateAsync();
}
