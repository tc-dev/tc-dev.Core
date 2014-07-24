using System.Security.Claims;

namespace tc_dev.Core.Identity.Models
{
    public class AppExternalLoginInfo
    {
        public string DefaultUserName { get; set; }

        public string Email { get; set; }

        public ClaimsIdentity ExternalIdentity { get; set; }

        public AppExternalLoginInfo Login { get; set; }
    }
}
