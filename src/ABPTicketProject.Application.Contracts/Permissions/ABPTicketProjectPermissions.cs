namespace ABPTicketProject.Permissions;

public static class ABPTicketProjectPermissions
{
    public const string GroupName = "ABPTicketProject";
    public const string UserGroup = GroupName + ".User";
    public const string SeeEvents = UserGroup + ".Events";
    public const string PurchaseTickets = UserGroup + ".EventsPurchase";
    public const string SeePurchased = UserGroup + ".EventsPurchased";
    public const string AccessFavorites = UserGroup + ".Favorites";
    public const string AgeRestriction = UserGroup + ".AgeRestriction";

    public const string SellerGroup = GroupName + ".Seller";
    public const string CreateEvent = SellerGroup + ".CreateEvent";
    public const string EditEvent = SellerGroup + ".EditEvent";
    public const string DeleteEvent = SellerGroup + ".DeleteEvent";
    public const string SeePurchases = SellerGroup + ".AccessPurchases";
    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
}
