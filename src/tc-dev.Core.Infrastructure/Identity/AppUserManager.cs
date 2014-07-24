using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using tc_dev.Core.Common.Utilities;
using tc_dev.Core.Identity;
using tc_dev.Core.Identity.Models;
using tc_dev.Core.Infrastructure.Identity.Models;
using tc_dev.Core.Infrastructure.Identity.Utilities;

namespace tc_dev.Core.Infrastructure.Identity
{
    public class AppUserManager : IAppUserManager
    {
        private readonly UserManager<AppIdentityUser, int> _userManager;
        private bool _disposed;

        public AppUserManager(UserManager<AppIdentityUser, int> userManager) {
            userManager.ThrowIfNull("userManager");

            _userManager = userManager;
        }

        public string AppCookie {
            get { return DefaultAuthenticationTypes.ApplicationCookie; }
        }

        public string ExternalBearer {
            get { return DefaultAuthenticationTypes.ExternalBearer; }
        }

        public string ExternalCookie {
            get { return DefaultAuthenticationTypes.ExternalCookie; }
        }

        public string TwoFactorCookie {
            get { return DefaultAuthenticationTypes.TwoFactorCookie; }
        }

        public string TwoFactorRememberBrowserCookie {
            get { return DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie; }
        }

        public AppIdentityResult AddLogin(int userId, AppUserLoginInfo loginInfo) {
            loginInfo.ThrowIfNull("loginInfo");

            var identityUserLoginInfo = IdentityModelFactory.Create(loginInfo);
            var identityResult = _userManager.AddLogin(userId, identityUserLoginInfo);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public async Task<AppIdentityResult> AddLoginAsync(int userId, AppUserLoginInfo loginInfo) {
            loginInfo.ThrowIfNull("loginInfo");

            var identityUserLoginInfo = IdentityModelFactory.Create(loginInfo);
            var identityResult = await _userManager.AddLoginAsync(userId, identityUserLoginInfo);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public AppIdentityResult AddPassword(int userId, string password) {
            password.ThrowIfNull("password");

            var identityResult = _userManager.AddPassword(userId, password);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public async Task<AppIdentityResult> AddPasswordAsync(int userId, string password) {
            password.ThrowIfNull("password");

            var identityResult = await _userManager.AddPasswordAsync(userId, password);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public AppIdentityResult ChangePassword(int userId, string oldPassword, string newPassword) {
            oldPassword.ThrowIfNull("oldPassword");
            newPassword.ThrowIfNull("newPassword");

            var identityResult = _userManager.ChangePassword(userId, oldPassword, newPassword);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public async Task<AppIdentityResult> ChangePasswordAsync(int userId, string oldPassword, string newPassword) {
            oldPassword.ThrowIfNull("oldPassword");
            newPassword.ThrowIfNull("newPassword");

            var identityResult = await _userManager.ChangePasswordAsync(userId, oldPassword, newPassword);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public AppIdentityResult Create(AppUser user) {
            user.ThrowIfNull("user");

            var appIdentityUser = IdentityModelFactory.Create(user);
            var identityResult = _userManager.Create(appIdentityUser);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            // if create is successful, copy the AppIdentityUser's properties
            // back to the AppUser that was passed in
            if (appIdentityResult.Succeeded)
                user.CopyFrom(appIdentityUser);

            return appIdentityResult;
        }

        public async Task<AppIdentityResult> CreateAsync(AppUser user) {
            user.ThrowIfNull("user");

            var appIdentityUser = IdentityModelFactory.Create(user);
            var identityResult = await _userManager.CreateAsync(appIdentityUser);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            // if create is successful, copy the AppIdentityUser's properties
            // back to the AppUser that was passed in
            if (appIdentityResult.Succeeded)
                user.CopyFrom(appIdentityUser);

            return appIdentityResult;
        }

        public AppIdentityResult Create(AppUser user, string password) {
            user.ThrowIfNull("user");
            password.ThrowIfNull("password");

            var appIdentityUser = IdentityModelFactory.Create(user);
            var identityResult = _userManager.Create(appIdentityUser, password);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            // if create is successful, copy the AppIdentityUser's properties
            // back to the AppUser that was passed in
            if (appIdentityResult.Succeeded)
                user.CopyFrom(appIdentityUser);

            return appIdentityResult;
        }

        public async Task<AppIdentityResult> CreateAsync(AppUser user, string password) {
            user.ThrowIfNull("user");
            password.ThrowIfNull("password");

            var appIdentityUser = IdentityModelFactory.Create(user);
            var identityResult = await _userManager.CreateAsync(appIdentityUser, password);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            // if create is successful, copy the AppIdentityUser's properties
            // back to the AppUser that was passed in
            if (appIdentityResult.Succeeded)
                user.CopyFrom(appIdentityUser);

            return appIdentityResult;
        }

        public ClaimsIdentity CreateIdentity(AppUser user, string authenticationType) {
            user.ThrowIfNull("user");
            authenticationType.ThrowIfNull("authenticationType");

            var appIdentityUser = IdentityModelFactory.Create(user);
            var claimsIdentity = _userManager.CreateIdentity(appIdentityUser, authenticationType);

            user.CopyFrom(appIdentityUser);

            return claimsIdentity;
        }

        public async Task<ClaimsIdentity> CreateIdentityAsyc(AppUser user, string authenticationType) {
            user.ThrowIfNull("user");
            authenticationType.ThrowIfNull("authenticationType");

            var appIdentityUser = IdentityModelFactory.Create(user);
            var claimsIdentity = await _userManager.CreateIdentityAsync(appIdentityUser, authenticationType);

            user.CopyFrom(appIdentityUser);

            return claimsIdentity;
        }

        public AppUser FindByEmail(string email) {
            email.ThrowIfNull("email");

            var appIdentityUser = _userManager.FindByEmail(email);
            var appUser = IdentityModelFactory.Create(appIdentityUser);

            return appUser;
        }

        public async Task<AppUser> FindByEmailAsync(string email) {
            email.ThrowIfNull("email");

            var appIdentityUser = await _userManager.FindByEmailAsync(email);
            var appUser = IdentityModelFactory.Create(appIdentityUser);

            return appUser;
        }

        public AppUser FindByUserLoginInfo(AppUserLoginInfo loginInfo) {
            loginInfo.ThrowIfNull("loginInfo");

            var userLoginInfo = IdentityModelFactory.Create(loginInfo);
            var appIdentityUser = _userManager.Find(userLoginInfo);
            var appUser = IdentityModelFactory.Create(appIdentityUser);

            return appUser;
        }

        public async Task<AppUser> FindByUserLoginInfoAsync(AppUserLoginInfo loginInfo) {
            loginInfo.ThrowIfNull("loginInfo");

            var userLoginInfo = IdentityModelFactory.Create(loginInfo);
            var appIdentityUser = await _userManager.FindAsync(userLoginInfo);
            var appUser = IdentityModelFactory.Create(appIdentityUser);

            return appUser;
        }

        public AppUser FindById(int userId) {
            var appIdentityUser = _userManager.FindById(userId);
            var appUser = IdentityModelFactory.Create(appIdentityUser);

            return appUser;
        }

        public async Task<AppUser> FindByIdAsync(int userId) {
            var appIdentityUser = await _userManager.FindByIdAsync(userId);
            var appUser = IdentityModelFactory.Create(appIdentityUser);

            return appUser;
        }

        public AppUser FindByUserName(string userName) {
            userName.ThrowIfNull("userName");

            var appIdentityUser = _userManager.FindByName(userName);
            var appUser = IdentityModelFactory.Create(appIdentityUser);

            return appUser;
        }

        public async Task<AppUser> FindByUserNameAsync(string userName) {
            userName.ThrowIfNull("userName");

            var appIdentityUser = await _userManager.FindByNameAsync(userName);
            var appUser = IdentityModelFactory.Create(appIdentityUser);

            return appUser;
        }

        public AppIdentityResult RemoveLogin(int userId, AppUserLoginInfo loginInfo) {
            loginInfo.ThrowIfNull("loginInfo");

            var userLoginInfo = IdentityModelFactory.Create(loginInfo);
            var identityResult = _userManager.RemoveLogin(userId, userLoginInfo);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public async Task<AppIdentityResult> RemoveLoginAsync(int userId, AppUserLoginInfo loginInfo) {
            loginInfo.ThrowIfNull("loginInfo");

            var userLoginInfo = IdentityModelFactory.Create(loginInfo);
            var identityResult = await _userManager.RemoveLoginAsync(userId, userLoginInfo);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing) {
            if (!_disposed && disposing) {
                if (_userManager != null) {
                    _userManager.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
