using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using tc_dev.Core.Domain;

namespace tc_dev.Core.Data
{
    public interface IQueryBuilder<TEntity, out TQueryBuilder>
        where TEntity : BaseEntity
        where TQueryBuilder : class
    {
        TQueryBuilder ById(int id);
        TQueryBuilder ByDateCreated(DateTime dateCreated);
        TQueryBuilder ByMinDateCreated(DateTime minDateCreated);
        TQueryBuilder ByMaxDateCreated(DateTime maxDateCreated);
        TQueryBuilder ByDateLastModified(DateTime dateLastModified);
        TQueryBuilder ByMinLastDateModified(DateTime minDateLastModified);
        TQueryBuilder ByMaxLastDateModified(DateTime maxDateLastModified);

        TQueryBuilder Include<T>(Expression<Func<TEntity, T>> property);
        TQueryBuilder OrderBy<T>(Expression<Func<TEntity, T>> property);
        TQueryBuilder OrderByDescending<T>(Expression<Func<TEntity, T>> property);
        TQueryBuilder Take(int count);
        TQueryBuilder Skip(int count);
        TQueryBuilder SkipWhile(Expression<Func<TEntity, bool>> predicate);
        TQueryBuilder After(int id);
        TQueryBuilder Before(int id);
        TQueryBuilder Distinct();

        IQueryable<TEntity> AsQueryable();
        bool Any();
        Task<bool> AnyAsync();
        IQueryable<TResult> Cast<TResult>();
        int Count();
        Task<int> CountAsync();
        TEntity First();
        Task<TEntity> FirstAsync();
        TEntity FirstOrDefault();
        Task<TEntity> FirstOrDefaultAsync();
        TEntity Last();
        TEntity LastOrDefault();
        TEntity Max();
        Task<TEntity> MaxAsync();
        IEnumerable<TResult> Select<TResult>(Func<TEntity, TResult> selector);
        IEnumerable<TResult> SelectMany<TResult>(Func<TEntity, IEnumerable<TResult>> selector);
        TEntity Single();
        Task<TEntity> SingleAsync();
        TEntity[] ToArray();
        Task<TEntity[]> ToArrayAsync();
        Dictionary<T, TEntity> ToDictionary<T>(Func<TEntity, T> keySelector);
        Task<Dictionary<T, TEntity>> ToDictionaryAsync<T>(Func<TEntity, T> keySelector);
        ILookup<T, TEntity> ToLookup<T>(Func<TEntity, T> keySelector);
        IEnumerable<TEntity> ToList();
        Task<IEnumerable<TEntity>> ToListAsync();
    }
}
