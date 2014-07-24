using tc_dev.Core.Common.Utilities;
using tc_dev.Core.Identity.Models;
using tc_dev.Core.Infrastructure.Identity.Models;

namespace tc_dev.Core.Infrastructure.Identity.Utilities
{
    public static class IdentityModelFactoryExtensions
    {
        public static AppRole CopyFrom(this AppRole source, AppIdentityRole identityRole) {
            source.ThrowIfNull("source");
            identityRole.ThrowIfNull("identityRole");

            source.Id = identityRole.Id;
            source.Name = identityRole.Name;
            foreach (var userRole in identityRole.Users)
                source.Users.Add(IdentityModelFactory.Create(userRole));

            return source;
        }

        public static AppUser CopyFrom(this AppUser source, AppIdentityUser identityUser) {
            source.ThrowIfNull("source");
            identityUser.ThrowIfNull("identityUser");

            source.Id = identityUser.Id;
            source.UserName = identityUser.UserName;
            source.Email = identityUser.Email;
            source.EmailConfirmed = identityUser.EmailConfirmed;
            source.PhoneNumber = identityUser.PhoneNumber;
            source.PhoneNumberConfirmed = identityUser.PhoneNumberConfirmed;
            source.AccessFailedCount = identityUser.AccessFailedCount;
            source.LockoutEnabled = identityUser.LockoutEnabled;
            source.LockoutEndDateUtc = identityUser.LockoutEndDateUtc;
            source.PasswordHash = identityUser.PasswordHash;
            source.SecurityStamp = identityUser.SecurityStamp;
            source.TwoFactorEnabled = identityUser.TwoFactorEnabled;

            foreach (var userRole in identityUser.Roles)
                source.Roles.Add(IdentityModelFactory.Create(userRole));
            foreach (var userLogin in identityUser.Logins)
                source.Logins.Add(IdentityModelFactory.Create(userLogin));
            foreach (var userClaim in identityUser.Claims)
                source.Claims.Add(IdentityModelFactory.Create(userClaim));

            return source;
        }
    }
}