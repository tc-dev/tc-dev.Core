using Microsoft.AspNet.Identity.EntityFramework;

namespace tc_dev.Core.Infrastructure.Identity.Models
{
    public class AppIdentityUser 
        : IdentityUser<int, AppIdentityUserLogin, AppIdentityUserRole, AppIdentityUserClaim>
    {
    }
}
