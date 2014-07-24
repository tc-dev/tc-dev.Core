using tc_dev.Core.Domain;

namespace tc_dev.Core.Data
{
    public interface IQueryableRepository<TEntity, out TQueryBuilder>
        where TEntity : BaseEntity
        where TQueryBuilder : class, IQueryBuilder<TEntity, TQueryBuilder>
    {
        TQueryBuilder Query();
    }
}
