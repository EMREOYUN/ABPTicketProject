using Volo.Abp.Settings;

namespace ABPTicketProject.Settings;

public class ABPTicketProjectSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ABPTicketProjectSettings.MySetting1));
    }
}
