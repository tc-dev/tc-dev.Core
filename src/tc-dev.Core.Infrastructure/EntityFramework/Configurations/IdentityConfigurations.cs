using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using tc_dev.Core.Infrastructure.Identity.Models;

namespace tc_dev.Core.Infrastructure.EntityFramework.Configurations
{
    public static class IdentityConfigurations
    {
        public static void Configure(this EntityTypeConfiguration<AppIdentityUser> source) {
            source
                .ToTable("IdentityUser")
                .Property(m => m.Id)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

        public static void Configure(this EntityTypeConfiguration<AppIdentityRole> source) {
            source
                .ToTable("IdentityRole")
                .Property(m => m.Id)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

        public static void Configure(this EntityTypeConfiguration<AppIdentityUserRole> source) {
            source
                .ToTable("IdentityUserRole");
        }

        public static void Configure(this EntityTypeConfiguration<AppIdentityUserLogin> source) {
            source
                .ToTable("IdentityUserLogin");
        }

        public static void Configure(this EntityTypeConfiguration<AppIdentityUserClaim> source) {
            source
                .ToTable("IdentityUserClaim")
                .Property(m => m.Id)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
