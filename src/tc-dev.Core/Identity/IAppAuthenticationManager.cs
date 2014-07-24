using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using tc_dev.Core.Identity.Models;

namespace tc_dev.Core.Identity
{
    public interface IAppAuthenticationManager
    {
        IEnumerable<AppAuthenticationDescription> GetExternalAuthenticationTypes();

        AppExternalLoginInfo GetExternalLoginInfo();
        Task<AppExternalLoginInfo> GetExternalLoginInfoAsync();

        void SignIn(params ClaimsIdentity[] identities);

        void SignOut(params string[] authenticationTypes);
    }
}
