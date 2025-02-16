using Abp.Authorization;
using OSW.Authorization.Roles;
using OSW.Authorization.Users;

namespace OSW.Authorization;

public class PermissionChecker : PermissionChecker<Role, User>
{
    public PermissionChecker(UserManager userManager)
        : base(userManager)
    {
    }
}
