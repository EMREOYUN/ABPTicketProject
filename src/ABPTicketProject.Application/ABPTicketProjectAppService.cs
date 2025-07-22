using ABPTicketProject.Localization;
using Volo.Abp.Application.Services;

namespace ABPTicketProject;

/* Inherit your application services from this class.
 */
public abstract class ABPTicketProjectAppService : ApplicationService
{
    protected ABPTicketProjectAppService()
    {
        LocalizationResource = typeof(ABPTicketProjectResource);
    }
}
