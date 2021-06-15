using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Mustafa.Authorization
{
    public class MustafaAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            // Products
            context.CreatePermission(PermissionNames.Product, L("Permission_Product"));
            context.CreatePermission(PermissionNames.Product_Create, L("Permission_Product_Create"));
            context.CreatePermission(PermissionNames.Product_Get, L("Permission_Product_Get"));
            context.CreatePermission(PermissionNames.Product_GetList, L("Permission_Product_GetList"));
            context.CreatePermission(PermissionNames.Product_Delete, L("Permission_Product_Delete"));
            context.CreatePermission(PermissionNames.Product_Update, L("Permission_Product_Update"));

            // Categories
            context.CreatePermission(PermissionNames.Category, L("Permission_Category"));
            context.CreatePermission(PermissionNames.Category_Create, L("Permission_Category_Create"));
            context.CreatePermission(PermissionNames.Category_Get, L("Permission_Category_Get"));
            context.CreatePermission(PermissionNames.Category_GetList, L("Permission_Category_GetList"));
            context.CreatePermission(PermissionNames.Category_Delete, L("Permission_Category_Delete"));
            context.CreatePermission(PermissionNames.Category_Update, L("Permission_Category_Update"));

            // StockMoves
            context.CreatePermission(PermissionNames.StockMove, L("Permission_StockMove"));
            context.CreatePermission(PermissionNames.StockMove_Create, L("Permission_StockMove_Create"));
            context.CreatePermission(PermissionNames.StockMove_Get, L("Permission_StockMove_Get"));
            context.CreatePermission(PermissionNames.StockMove_GetList, L("Permission_StockMove_GetList"));
            context.CreatePermission(PermissionNames.StockMove_Delete, L("Permission_StockMove_Delete"));
            context.CreatePermission(PermissionNames.StockMove_Update, L("Permission_StockMove_Update"));

            // Unitlines
            context.CreatePermission(PermissionNames.Unitline, L("Permission_Unitline"));
            context.CreatePermission(PermissionNames.Unitline_Create, L("Permission_Unitline_Create"));
            context.CreatePermission(PermissionNames.Unitline_Get, L("Permission_Unitline_Get"));
            context.CreatePermission(PermissionNames.Unitline_GetList, L("Permission_Unitline_GetList"));
            context.CreatePermission(PermissionNames.Unitline_Delete, L("Permission_Unitline_Delete"));
            context.CreatePermission(PermissionNames.Unitline_Update, L("Permission_Unitline_Update"));

            // Vendors
            context.CreatePermission(PermissionNames.Vendor, L("Permission_Vendor"));
            context.CreatePermission(PermissionNames.Vendor_Create, L("Permission_Vendor_Create"));
            context.CreatePermission(PermissionNames.Vendor_Get, L("Permission_Vendor_Get"));
            context.CreatePermission(PermissionNames.Vendor_GetList, L("Permission_Vendor_GetList"));
            context.CreatePermission(PermissionNames.Vendor_Delete, L("Permission_Vendor_Delete"));
            context.CreatePermission(PermissionNames.Vendor_Update, L("Permission_Vendor_Update"));

            // Warehouses
            context.CreatePermission(PermissionNames.Warehouse, L("Permission_Warehouse"));
            context.CreatePermission(PermissionNames.Warehouse_Create, L("Permission_Warehouse_Create"));
            context.CreatePermission(PermissionNames.Warehouse_Get, L("Permission_Warehouse_Get"));
            context.CreatePermission(PermissionNames.Warehouse_GetList, L("Permission_Warehouse_GetList"));
            context.CreatePermission(PermissionNames.Warehouse_Delete, L("Permission_Warehouse_Delete"));
            context.CreatePermission(PermissionNames.Warehouse_Update, L("Permission_Warehouse_Update"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MustafaConsts.LocalizationSourceName);
        }
    }
}
