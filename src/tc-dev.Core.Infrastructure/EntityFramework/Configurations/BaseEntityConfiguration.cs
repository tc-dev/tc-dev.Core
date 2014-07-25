using System.Data.Entity.ModelConfiguration;
using tc_dev.Core.Domain;

namespace tc_dev.Core.Infrastructure.EntityFramework.Configurations
{
    public abstract class BaseEntityConfiguration<TEntity> : EntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        protected BaseEntityConfiguration() {

            HasKey(m => m.Id);

            Property(m => m.DateCreated)
                .IsRequired();

            Property(m => m.DateLastModified)
                .IsOptional();

        }
    }
}
