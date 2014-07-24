using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using tc_dev.Core.Common.Utilities;
using tc_dev.Core.Data;
using tc_dev.Core.Domain;

namespace tc_dev.Core.Infrastructure.EntityFramework
{
    public abstract class QueryBuilder<TEntity, TQueryBuilder> 
        : IQueryBuilder<TEntity, TQueryBuilder>
        where TEntity : BaseEntity
        where TQueryBuilder : class
    {
        protected QueryBuilder(IQueryable<TEntity> query) {
            query.ThrowIfNull("query");

            Query = query;
        }

        protected IQueryable<TEntity> Query { get; set; }

        public TQueryBuilder ById(int id) {
            Query = Query.Where(m => m.Id == id);

            return this as TQueryBuilder;
        }

        public TQueryBuilder ByDateCreated(DateTime dateCreated) {
            Query = Query.Where(m => m.DateCreated == dateCreated);

            return this as TQueryBuilder;
        }

        public TQueryBuilder ByMinDateCreated(DateTime minDateCreated) {
            Query = Query.Where(m => m.DateCreated >= minDateCreated);

            return this as TQueryBuilder;
        }

        public TQueryBuilder ByMaxDateCreated(DateTime maxDateCreated) {
            Query = Query.Where(m => m.DateCreated <= maxDateCreated);

            return this as TQueryBuilder;
        }

        public TQueryBuilder ByDateLastModified(DateTime dateLastModified) {
            Query = Query.Where(m => m.DateLastModified == dateLastModified);

            return this as TQueryBuilder;
        }

        public TQueryBuilder ByMinLastDateModified(DateTime minDateLastModified) {
            Query = Query.Where(m => m.DateLastModified >= minDateLastModified);

            return this as TQueryBuilder;
        }

        public TQueryBuilder ByMaxLastDateModified(DateTime maxDateLastModified) {
            Query = Query.Where(m => m.DateLastModified <= maxDateLastModified);

            return this as TQueryBuilder;
        }


        public TQueryBuilder Include<T>(Expression<Func<TEntity, T>> property) {
            property.ThrowIfNull("property");

            Query = Query.Include(property);

            return this as TQueryBuilder;
        }

        public TQueryBuilder OrderBy<T>(Expression<Func<TEntity, T>> property) {
            property.ThrowIfNull("property");

            Query = Query.OrderBy(property);

            return this as TQueryBuilder;
        }

        public TQueryBuilder OrderByDescending<T>(Expression<Func<TEntity, T>> property) {
            property.ThrowIfNull("property");

            Query = Query.OrderByDescending(property);

            return this as TQueryBuilder;
        }

        public TQueryBuilder Take(int count) {
            Query = Query.Take(count);

            return this as TQueryBuilder;
        }

        public TQueryBuilder Skip(int count) {
            Query = Query.Skip(count);

            return this as TQueryBuilder;
        }

        public TQueryBuilder SkipWhile(Expression<Func<TEntity, bool>> predicate) {
            predicate.ThrowIfNull("predicate");

            Query = Query.SkipWhile(predicate);

            return this as TQueryBuilder;
        }

        public TQueryBuilder After(int id) {
            Query = Query.Where(m => m.Id > id);

            return this as TQueryBuilder;
        }

        public TQueryBuilder Before(int id) {
            Query = Query.Where(m => m.Id < id);

            return this as TQueryBuilder;
        }

        public TQueryBuilder Distinct() {
            Query = Query.Distinct();

            return this as TQueryBuilder;
        }


        public IQueryable<TEntity> AsQueryable() {
            return Query.AsQueryable();
        }

        public bool Any() {
            return Query.Any();
        }

        public async Task<bool> AnyAsync() {
            return await Query.AnyAsync();
        }

        public IQueryable<TResult> Cast<TResult>() {
            return Query.Cast<TResult>();
        }

        public int Count() {
            return Query.Count();
        }

        public async Task<int> CountAsync() {
            return await Query.CountAsync();
        }

        public TEntity First() {
            return Query.First();
        }

        public async Task<TEntity> FirstAsync() {
            return await Query.FirstAsync();
        }

        public TEntity FirstOrDefault() {
            return Query.FirstOrDefault();
        }

        public async Task<TEntity> FirstOrDefaultAsync() {
            return await Query.FirstOrDefaultAsync();
        }

        public TEntity Last() {
            return Query.Last();
        }

        public TEntity LastOrDefault() {
            return Query.LastOrDefault();
        }

        public TEntity Max() {
            return Query.Max();
        }

        public async Task<TEntity> MaxAsync() {
            return await Query.MaxAsync();
        }

        public IEnumerable<TResult> Select<TResult>(Func<TEntity, TResult> selector) {
            selector.ThrowIfNull("selector");

            return Query.Select(selector);
        }

        public IEnumerable<TResult> SelectMany<TResult>(Func<TEntity, IEnumerable<TResult>> selector) {
            selector.ThrowIfNull("selector");

            return Query.SelectMany(selector);
        }

        public TEntity Single() {
            return Query.Single();
        }

        public async Task<TEntity> SingleAsync() {
            return await Query.SingleAsync();
        }

        public TEntity[] ToArray() {
            return Query.ToArray();
        }

        public async Task<TEntity[]> ToArrayAsync() {
            return await Query.ToArrayAsync();
        }

        public Dictionary<T, TEntity> ToDictionary<T>(Func<TEntity, T> keySelector) {
            keySelector.ThrowIfNull("keySelector");

            return Query.ToDictionary(keySelector);
        }

        public async Task<Dictionary<T, TEntity>> ToDictionaryAsync<T>(Func<TEntity, T> keySelector) {
            keySelector.ThrowIfNull("keySelector");

            return await Query.ToDictionaryAsync(keySelector);
        }

        public ILookup<T, TEntity> ToLookup<T>(Func<TEntity, T> keySelector) {
            keySelector.ThrowIfNull("keySelector");

            return Query.ToLookup(keySelector);
        }

        public IEnumerable<TEntity> ToList() {
            return Query.ToList();
        }

        public async Task<IEnumerable<TEntity>> ToListAsync() {
            return await Query.ToListAsync();
        }
    }
}
