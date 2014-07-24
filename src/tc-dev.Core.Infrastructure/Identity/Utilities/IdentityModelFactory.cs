using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using tc_dev.Core.Common.Utilities;
using tc_dev.Core.Identity.Models;
using tc_dev.Core.Infrastructure.Identity.Models;

namespace tc_dev.Core.Infrastructure.Identity.Utilities
{
    public class IdentityModelFactory
    {
        public static AppUser Create(AppIdentityUser identityUser) {
            if (identityUser == null)
                return null;

            var appUser = new AppUser {
                Id = identityUser.Id,
                Email = identityUser.Email,
                UserName = identityUser.UserName,
                EmailConfirmed = identityUser.EmailConfirmed,
                AccessFailedCount = identityUser.AccessFailedCount,
                LockoutEnabled = identityUser.LockoutEnabled,
                LockoutEndDateUtc = identityUser.LockoutEndDateUtc,
                PasswordHash = identityUser.PasswordHash,
                PhoneNumber = identityUser.PhoneNumber,
                PhoneNumberConfirmed = identityUser.PhoneNumberConfirmed,
                SecurityStamp = identityUser.SecurityStamp,
                TwoFactorEnabled = identityUser.TwoFactorEnabled
            };
            foreach (var role in identityUser.Roles)
                appUser.Roles.Add(Create(role));
            foreach (var login in identityUser.Logins)
                appUser.Logins.Add(Create(login));
            foreach (var claim in identityUser.Claims)
                appUser.Claims.Add(Create(claim));

            return appUser;
        }

        public static AppIdentityUser Create(AppUser appUser) {
            if (appUser == null)
                return null;

            var appIdentityUser = new AppIdentityUser {
                Id = appUser.Id,
                Email = appUser.Email,
                UserName = appUser.UserName,
                EmailConfirmed = appUser.EmailConfirmed,
                AccessFailedCount = appUser.AccessFailedCount,
                LockoutEnabled = appUser.LockoutEnabled,
                LockoutEndDateUtc = appUser.LockoutEndDateUtc,
                PasswordHash = appUser.PasswordHash,
                PhoneNumber = appUser.PhoneNumber,
                PhoneNumberConfirmed = appUser.PhoneNumberConfirmed,
                SecurityStamp = appUser.SecurityStamp,
                TwoFactorEnabled = appUser.TwoFactorEnabled
            };
            foreach (var role in appUser.Roles)
                appIdentityUser.Roles.Add(Create(role));
            foreach (var login in appUser.Logins)
                appIdentityUser.Logins.Add(Create(login));
            foreach (var claim in appUser.Claims)
                appIdentityUser.Claims.Add(Create(claim));

            return appIdentityUser;
        }

        public static AppRole Create(AppIdentityRole identityRole) {
            if (identityRole == null)
                return null;

            var appRole = new AppRole {
                Id = identityRole.Id,
                Name = identityRole.Name
            };
            foreach (var userRole in identityRole.Users)
                appRole.Users.Add(Create(userRole));

            return appRole;
        }

        public static AppIdentityRole Create(AppRole appRole) {
            if (appRole == null)
                return null;

            var appIdentityRole = new AppIdentityRole {
                Id = appRole.Id,
                Name = appRole.Name
            };
            foreach (var userRole in appRole.Users)
                appIdentityRole.Users.Add(Create(userRole));

            return appIdentityRole;
        }

        public static AppUserRole Create(AppIdentityUserRole identityUserRole) {
            if (identityUserRole == null)
                return null;

            var appUserRole = new AppUserRole {
                UserId = identityUserRole.UserId,
                RoleId = identityUserRole.RoleId
            };

            return appUserRole;
        }

        public static AppIdentityUserRole Create(AppUserRole appUserRole) {
            if (appUserRole == null)
                return null;

            var appIdentityUserRole = new AppIdentityUserRole {
                UserId = appUserRole.UserId,
                RoleId = appUserRole.RoleId
            };

            return appIdentityUserRole;
        }

        public static AppUserLogin Create(AppIdentityUserLogin identityUserLogin) {
            if (identityUserLogin == null)
                return null;

            var appUserLogin = new AppUserLogin {
                LoginProvider = identityUserLogin.LoginProvider,
                ProviderKey = identityUserLogin.ProviderKey,
                UserId = identityUserLogin.UserId
            };

            return appUserLogin;
        }

        public static AppIdentityUserLogin Create(AppUserLogin appUserLogin) {
            if (appUserLogin == null)
                return null;

            var appIdentityUserLogin = new AppIdentityUserLogin {
                LoginProvider = appUserLogin.LoginProvider,
                ProviderKey = appUserLogin.ProviderKey,
                UserId = appUserLogin.UserId
            };

            return appIdentityUserLogin;
        }

        public static AppUserClaim Create(AppIdentityUserClaim identityUserClaim) {
            if (identityUserClaim == null)
                return null;

            var appUserClaim = new AppUserClaim {
                Id = identityUserClaim.Id,
                UserId = identityUserClaim.UserId,
                ClaimType = identityUserClaim.ClaimType,
                ClaimValue = identityUserClaim.ClaimValue
            };

            return appUserClaim;
        }

        public static AppIdentityUserClaim Create(AppUserClaim appUserClaim) {
            if (appUserClaim == null)
                return null;

            var appIdentityUserClaim = new AppIdentityUserClaim {
                Id = appUserClaim.Id,
                UserId = appUserClaim.UserId,
                ClaimType = appUserClaim.ClaimType,
                ClaimValue = appUserClaim.ClaimValue
            };

            return appIdentityUserClaim;
        }

        public static AppUserLoginInfo Create(UserLoginInfo identityUserLoginInfo) {
            if (identityUserLoginInfo == null)
                return null;

            var appUserLoginInfo = new AppUserLoginInfo(
                identityUserLoginInfo.LoginProvider, identityUserLoginInfo.ProviderKey);

            return appUserLoginInfo;
        }

        public static UserLoginInfo Create(AppUserLoginInfo appUserLoginInfo) {
            if (appUserLoginInfo == null)
                return null;

            var userLoginInfo = new UserLoginInfo(
                appUserLoginInfo.LoginProvider, appUserLoginInfo.ProviderKey);

            return userLoginInfo;
        }

        public static AppAuthenticationDescription Create(AuthenticationDescription authDescrip) {
            if (authDescrip == null)
                return null;

            var appAuthenticationDescrip = new AppAuthenticationDescription {
                AuthenticationType = authDescrip.AuthenticationType,
                Caption = authDescrip.Caption,
            };
            foreach (var property in authDescrip.Properties)
                appAuthenticationDescrip.Properties.Add(property.Key, property.Value);

            return appAuthenticationDescrip;
        }

        public static AuthenticationDescription Create(AppAuthenticationDescription appAuthDescrip) {
            if (appAuthDescrip == null)
                return null;

            var authenticationDescrip = new AuthenticationDescription {
                AuthenticationType = appAuthDescrip.AuthenticationType,
                Caption = appAuthDescrip.Caption,
            };
            foreach (var property in appAuthDescrip.Properties)
                authenticationDescrip.Properties.Add(property.Key, property.Value);

            return authenticationDescrip;
        }

        public static AppExternalLoginInfo Create(ExternalLoginInfo externalLoginInfo) {
            if (externalLoginInfo == null)
                return null;

            var appExternalLoginInfo = new AppExternalLoginInfo {
                DefaultUserName = externalLoginInfo.DefaultUserName,
                Email = externalLoginInfo.Email,
                ExternalIdentity = externalLoginInfo.ExternalIdentity,
                Login = Create(externalLoginInfo.Login)
            };

            return appExternalLoginInfo;
        }

        public static AppIdentityResult Create(IdentityResult identityResult) {
            if (identityResult == null)
                return null;

            var appIdentityResult = new AppIdentityResult(
                identityResult.Errors, identityResult.Succeeded);

            return appIdentityResult;
        }
    }
}
