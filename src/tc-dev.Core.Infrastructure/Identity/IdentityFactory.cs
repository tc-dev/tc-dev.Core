using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using tc_dev.Core.Infrastructure.Identity.Models;

namespace tc_dev.Core.Infrastructure.Identity
{
    public class IdentityFactory
    {
        public static UserManager<AppIdentityUser, int> CreateUserManager(DbContext context) {
            var manager = new UserManager<AppIdentityUser, int>(
                new UserStore<AppIdentityUser, AppIdentityRole, int, AppIdentityUserLogin, AppIdentityUserRole, AppIdentityUserClaim>(context));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<AppIdentityUser, int>(manager) {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator {
                RequiredLength = 6
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = false;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<AppIdentityUser, int> {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<AppIdentityUser, int> {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });

            // TODO
            //manager.EmailService = new EmailService();
            //manager.SmsService = new SmsService();

            return manager;
        }

        public static RoleManager<AppIdentityRole, int> CreateRoleManager(DbContext context) {
            return new RoleManager<AppIdentityRole, int>(new RoleStore<AppIdentityRole, int, AppIdentityUserRole>(context));
        }
    }
}
