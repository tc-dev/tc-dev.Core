﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace tc_dev.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        void BeginTransaction();
        int Commit();
        Task<int> CommitAsync();
        void Rollback();
    }
}
