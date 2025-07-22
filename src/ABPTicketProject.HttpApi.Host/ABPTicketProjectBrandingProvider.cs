using Microsoft.Extensions.Localization;
using ABPTicketProject.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ABPTicketProject;

[Dependency(ReplaceServices = true)]
public class ABPTicketProjectBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<ABPTicketProjectResource> _localizer;

    public ABPTicketProjectBrandingProvider(IStringLocalizer<ABPTicketProjectResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
