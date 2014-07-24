using System;
using System.Collections.Generic;
using tc_dev.Core.Domain;

namespace tc_dev.Core.Data
{
    public interface IPersistableRepository<in TEntity> : IDisposable
        where TEntity : BaseEntity
    {
        void Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void Remove(IEnumerable<TEntity> entities);
    }
}
