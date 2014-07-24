using System;
using System.Collections.Generic;

namespace tc_dev.Core.Identity.Models
{
    public class AppUser
    {
        public AppUser() {
            Claims = new List<AppUserClaim>();
            Roles = new List<AppUserRole>();
            Logins = new List<AppUserLogin>();
        }
        public virtual int AccessFailedCount { get; set; }
        public virtual ICollection<AppUserClaim> Claims { get; private set; }
        public virtual string Email { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual int Id { get; set; }
        public virtual bool LockoutEnabled { get; set; }
        public virtual DateTime? LockoutEndDateUtc { get; set; }
        public virtual ICollection<AppUserLogin> Logins { get; private set; }
        public virtual string PasswordHash { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual bool PhoneNumberConfirmed { get; set; }
        public virtual ICollection<AppUserRole> Roles { get; private set; }
        public virtual string SecurityStamp { get; set; }
        public virtual bool TwoFactorEnabled { get; set; }
        public virtual string UserName { get; set; }
    }
}
