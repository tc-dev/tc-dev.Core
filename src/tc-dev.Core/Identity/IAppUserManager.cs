using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using tc_dev.Core.Identity.Models;

namespace tc_dev.Core.Identity
{
    public interface IAppUserManager : IDisposable
    {
        string AppCookie { get; }
        string ExternalBearer { get; }
        string ExternalCookie { get; }
        string TwoFactorCookie { get; }
        string TwoFactorRememberBrowserCookie { get; }

        Task<AppIdentityResult> AccessFailedAsync(int userId);
        Task<AppIdentityResult> AddClaimAsync(int userId, Claim claim);
        Task<AppIdentityResult> AddLoginAsync(int userId, AppUserLoginInfo login);
        Task<AppIdentityResult> AddToRoleAsync(int userId, string role);
        AppIdentityResult AddToRole(int userId, string role);
        Task<AppIdentityResult> AddPasswordAsync(int userId, string password);
        Task<AppIdentityResult> AddUserToRolesAsync(int userId, IList<string> roles);
        Task<AppIdentityResult> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
        Task<AppIdentityResult> ChangePhoneNumberAsync(int userId, string phoneNumber, string token);
        void Challenge(string redirectUri, string xsrfKey, int? userId, params string[] authenticationTypes);
        Task<bool> CheckPasswordAsync(AppUser user, string password);
        Task<AppIdentityResult> ConfirmEmailAsync(int userId, string token);
        Task<AppIdentityResult> CreateAsync(AppUser user);
        Task<AppIdentityResult> CreateAsync(AppUser user, string password);
        ClaimsIdentity CreateIdentity(AppUser user, string authenticationType);
        Task<ClaimsIdentity> CreateIdentityAsync(AppUser user, string authenticationType);
        AppIdentityResult Create(AppUser user);
        AppIdentityResult Create(AppUser user, string password);
        ClaimsIdentity CreateTwoFactorRememberBrowserIdentity(int userId);
        Task<AppIdentityResult> DeleteAsync(int userId);
        Task<SignInStatus> ExternalSignIn(AppExternalLoginInfo loginInfo, bool isPersistent);
        Task<AppUser> FindAsync(AppUserLoginInfo login);
        Task<AppUser> FindAsync(string userName, string password);
        Task<AppUser> FindByEmailAsync(string email);
        AppUser FindById(int userId);
        Task<AppUser> FindByIdAsync(int userId);
        Task<AppUser> FindByNameAsync(string userName);
        AppUser FindByName(string userName);
        Task<string> GenerateChangePhoneNumberTokenAsync(int userId, string phoneNumber);
        Task<string> GenerateEmailConfirmationTokenAsync(int userId);
        Task<string> GeneratePasswordResetTokenAsync(int userId);
        Task<string> GenerateTwoFactorTokenAsync(int userId, string twoFactorProvider);
        Task<string> GenerateUserTokenAsync(string purpose, int userId);
        Task<int> GetAccessFailedCountAsync(int userId);
        Task<IList<Claim>> GetClaimsAsync(int userId);
        Task<string> GetEmailAsync(int userId);
        IEnumerable<AppAuthenticationDescription> GetExternalAuthenticationTypes();
        Task<ClaimsIdentity> GetExternalIdentityAsync(string externalAuthenticationType);
        AppExternalLoginInfo GetExternalLoginInfo();
        AppExternalLoginInfo GetExternalLoginInfo(string xsrfKey, string expectedValue);
        Task<AppExternalLoginInfo> GetExternalLoginInfoAsync();
        Task<AppExternalLoginInfo> GetExternalLoginInfoAsync(string xsrfKey, string expectedValue);
        Task<bool> GetLockoutEnabledAsync(int userId);
        Task<DateTimeOffset> GetLockoutEndDateAsync(int userId);
        IList<AppUserLoginInfo> GetLogins(int userId);
        Task<IList<AppUserLoginInfo>> GetLoginsAsync(int userId);
        Task<string> GetPhoneNumberAsync(int userId);
        Task<IList<string>> GetRolesAsync(int userId);
        IList<string> GetRoles(int userId);
        Task<string> GetSecurityStampAsync(int userId);
        Task<bool> GetTwoFactorEnabledAsync(int userId);
        Task<IList<string>> GetValidTwoFactorProvidersAsync(int userId);
        Task<int?> GetVerifiedUserIdAsync();
        Task<bool> HasBeenVerified();
        Task<bool> HasPasswordAsync(int userId);
        Task<bool> IsEmailConfirmedAsync(int userId);
        Task<bool> IsInRoleAsync(int userId, string role);
        Task<bool> IsLockedOutAsync(int userId);
        Task<bool> IsPhoneNumberConfirmedAsync(int userId);
        Task<AppIdentityResult> NotifyTwoFactorTokenAsync(int userId, string twoFactorProvider, string token);
        Task<SignInStatus> PasswordSignIn(string userName, string password, bool isPersistent, bool shouldLockout);
        Task<AppIdentityResult> RemoveClaimAsync(int userId, Claim claim);
        Task<AppIdentityResult> RemoveFromRoleAsync(int userId, string role);
        Task<AppIdentityResult> RemoveLoginAsync(int userId, AppUserLoginInfo login);
        Task<AppIdentityResult> RemovePasswordAsync(int userId);
        Task<AppIdentityResult> RemoveUserFromRolesAsync(int userId, IList<string> roles);
        Task<AppIdentityResult> ResetAccessFailedCountAsync(int userId);
        Task<AppIdentityResult> ResetPasswordAsync(int userId, string token, string newPassword);
        Task SendEmailAsync(int userId, string subject, string body);
        Task SendSmsAsync(int userId, string message);
        Task SendSmsAsync(AppMessage message);
        Task<bool> SendTwoFactorCode(string provider);
        Task<AppIdentityResult> SetEmailAsync(int userId, string email);
        Task<AppIdentityResult> SetLockoutEnabledAsync(int userId, bool enabled);
        AppIdentityResult SetLockoutEnabled(int userId, bool enabled);
        Task<AppIdentityResult> SetLockoutEndDateAsync(int userId, DateTimeOffset lockoutEnd);
        Task<AppIdentityResult> SetPhoneNumberAsync(int userId, string phoneNumber);
        Task<AppIdentityResult> SetTwoFactorEnabledAsync(int userId, bool enabled);
        Task<SignInStatus> SignInOrTwoFactor(AppUser user, bool isPersistent);
        void SignIn(params ClaimsIdentity[] identities);
        void SignIn(bool isPersistent, params ClaimsIdentity[] identities);
        void SignIn(AppUser user, bool isPersistent, bool rememberBrowser);
        Task SignInAsync(AppUser user, bool isPersistent, bool rememberBrowser);
        void SignOut(params string[] authenticationTypes);
        Task<bool> TwoFactorBrowserRememberedAsync(int userId);
        Task<SignInStatus> TwoFactorSignIn(string provider, string code, bool isPersistent, bool rememberBrowser);
        Task<AppIdentityResult> UpdateAsync(int userId);
        Task<AppIdentityResult> UpdateSecurityStampAsync(int userId);
        IEnumerable<AppUser> GetUsers();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<bool> VerifyChangePhoneNumberTokenAsync(int userId, string token, string phoneNumber);
        Task<bool> VerifyTwoFactorTokenAsync(int userId, string twoFactorProvider, string token);
        Task<bool> VerifyUserTokenAsync(int userId, string purpose, string token);

    }
}
