using System;
using System.Collections.Generic;
using System.Data.Entity;
using tc_dev.Core.Common.Utilities;
using tc_dev.Core.Data;
using tc_dev.Core.Domain;

namespace tc_dev.Core.Infrastructure.EntityFramework
{
    public abstract class PersistableRepository<TEntity> : IPersistableRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly IDbContext _context;
        private bool _disposed;

        protected PersistableRepository(IDbContext context) {
            context.ThrowIfNull("context");

            _context = context;
            DbSet = context.Set<TEntity>();
        }

        protected IDbSet<TEntity> DbSet { get; private set; }

        public void Insert(TEntity entity) {
            entity.ThrowIfNull("entity");

            entity.DateCreated = DateTime.Now;
            _context.SetAsAdded(entity);
        }

        public void Insert(IEnumerable<TEntity> entities) {
            entities.ThrowIfNull("entities");

            foreach (var entity in entities)
                Insert(entity);
        }

        public void Update(TEntity entity) {
            entity.ThrowIfNull("entity");

            entity.DateLastModified = DateTime.Now;
            _context.SetAsModified(entity);
        }

        public void Update(IEnumerable<TEntity> entities) {
            entities.ThrowIfNull("entities");

            foreach (var entity in entities)
                Update(entity);
        }

        public void Remove(TEntity entity) {
            entity.ThrowIfNull("entity");

            _context.SetAsDeleted(entity);
        }

        public void Remove(IEnumerable<TEntity> entities) {
            entities.ThrowIfNull("entities");

            foreach (var entity in entities)
                _context.SetAsModified(entity);
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing) {
            if (!_disposed && disposing) {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}
