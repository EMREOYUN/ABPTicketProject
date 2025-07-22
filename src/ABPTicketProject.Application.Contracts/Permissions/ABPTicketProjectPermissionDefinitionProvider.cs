using ABPTicketProject.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace ABPTicketProject.Permissions;

public class ABPTicketProjectPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ABPTicketProjectPermissions.GroupName);
        var userGroup = myGroup.AddPermission(ABPTicketProjectPermissions.UserGroup, L("Permission:User"));
        userGroup.AddChild(ABPTicketProjectPermissions.SeeEvents, L("Permission:SeeEvents"));
        userGroup.AddChild(ABPTicketProjectPermissions.PurchaseTickets, L("Permission:PurchaseTickets"));
        userGroup.AddChild(ABPTicketProjectPermissions.SeePurchased, L("Permission:SeePurchased"));
        userGroup.AddChild(ABPTicketProjectPermissions.AccessFavorites, L("Permission:AccessFavorites"));
        userGroup.AddChild(ABPTicketProjectPermissions.AgeRestriction, L("Permission:AgeRestriction"));
        var sellerGroup = myGroup.AddPermission(ABPTicketProjectPermissions.SellerGroup, L("Permission:Seller"));
        sellerGroup.AddChild(ABPTicketProjectPermissions.CreateEvent, L("Permission:CreateEvent"));
        sellerGroup.AddChild(ABPTicketProjectPermissions.EditEvent, L("Permission:EditEvent"));
        sellerGroup.AddChild(ABPTicketProjectPermissions.DeleteEvent, L("Permission:DeleteEvent"));
        sellerGroup.AddChild(ABPTicketProjectPermissions.SeePurchases, L("Permission:SeePurchases"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ABPTicketProjectPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ABPTicketProjectResource>(name);
    }
}
