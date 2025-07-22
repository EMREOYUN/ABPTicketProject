using ABPTicketProject.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ABPTicketProject.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ABPTicketProjectController : AbpControllerBase
{
    protected ABPTicketProjectController()
    {
        LocalizationResource = typeof(ABPTicketProjectResource);
    }
}
