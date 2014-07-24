using System.Collections.Generic;

namespace tc_dev.Core.Identity.Models
{
    public class AppRole
    {
        public AppRole() {
            Users = new List<AppUserRole>();
        }

        public int Id {
            get;
            set;
        }

        public virtual ICollection<AppUserRole> Users { get; private set; }

        public string Name { get; set; }
    }
}
