using Abp.Authorization;
using Mustafa.Authorization.Roles;
using Mustafa.Authorization.Users;

namespace Mustafa.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
