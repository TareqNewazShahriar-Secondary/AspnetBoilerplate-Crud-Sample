using Abp.Authorization;
using Testing.Authorization.Roles;
using Testing.Authorization.Users;

namespace Testing.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
