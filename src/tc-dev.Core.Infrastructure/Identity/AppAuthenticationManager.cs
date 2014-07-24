using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using tc_dev.Core.Common.Utilities;
using tc_dev.Core.Identity;
using tc_dev.Core.Identity.Models;
using tc_dev.Core.Infrastructure.Identity.Utilities;

namespace tc_dev.Core.Infrastructure.Identity
{
    public class AppAuthenticationManager : IAppAuthenticationManager
    {
        private readonly IAuthenticationManager _authenticationManager;

        public AppAuthenticationManager(IAuthenticationManager authenticationManager) {
            authenticationManager.ThrowIfNull("authenticatonManager");

            _authenticationManager = authenticationManager;
        }

        public IEnumerable<AppAuthenticationDescription> GetExternalAuthenticationTypes() {
            var authenticationDescriptions = _authenticationManager.GetExternalAuthenticationTypes();
            var appAuthenticationDescriptions = authenticationDescriptions.Select(IdentityModelFactory.Create);

            return appAuthenticationDescriptions;
        }

        public AppExternalLoginInfo GetExternalLoginInfo() {
            var externalLoginInfo = _authenticationManager.GetExternalLoginInfo();
            var appExternalLoginInfos = IdentityModelFactory.Create(externalLoginInfo);

            return appExternalLoginInfos;
        }

        public async Task<AppExternalLoginInfo> GetExternalLoginInfoAsync() {
            var externalLoginInfo = await _authenticationManager.GetExternalLoginInfoAsync();
            var appExternalLoginInfos = IdentityModelFactory.Create(externalLoginInfo);

            return appExternalLoginInfos;
        }

        public void SignIn(params ClaimsIdentity[] identities) {
            identities.ThrowIfNull("identities");

            _authenticationManager.SignIn(identities);
        }

        public void SignOut(params string[] authenticationTypes) {
            authenticationTypes.ThrowIfNull("authenticationTypes");

            _authenticationManager.SignOut(authenticationTypes);
        }
    }
}
