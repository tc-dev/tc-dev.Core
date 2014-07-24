using System;
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

        AppIdentityResult AddLogin(int userId, AppUserLoginInfo loginInfo);
        Task<AppIdentityResult> AddLoginAsync(int userId, AppUserLoginInfo loginInfo);

        AppIdentityResult AddPassword(int userId, string password);
        Task<AppIdentityResult> AddPasswordAsync(int userId, string password);

        AppIdentityResult ChangePassword(int userId, string oldPassword, string newPassword);
        Task<AppIdentityResult> ChangePasswordAsync(int userId, string oldPassword, string newPassword);

        AppIdentityResult Create(AppUser user);
        Task<AppIdentityResult> CreateAsync(AppUser user);

        AppIdentityResult Create(AppUser user, string password);
        Task<AppIdentityResult> CreateAsync(AppUser user, string password);

        ClaimsIdentity CreateIdentity(AppUser user, string authenticationType);
        Task<ClaimsIdentity> CreateIdentityAsyc(AppUser user, string authenticationType);

        AppUser FindByEmail(string email);
        Task<AppUser> FindByEmailAsync(string email);

        AppUser FindByUserLoginInfo(AppUserLoginInfo loginInfo);
        Task<AppUser> FindByUserLoginInfoAsync(AppUserLoginInfo loginInfo);

        AppUser FindById(int userId);
        Task<AppUser> FindByIdAsync(int userId);

        AppUser FindByUserName(string userName);
        Task<AppUser> FindByUserNameAsync(string userName);

        AppIdentityResult RemoveLogin(int userId, AppUserLoginInfo loginInfo);
        Task<AppIdentityResult> RemoveLoginAsync(int userId, AppUserLoginInfo loginInfo);
    }
}
