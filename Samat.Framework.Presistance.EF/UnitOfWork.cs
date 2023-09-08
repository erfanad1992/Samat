using Microsoft.EntityFrameworkCore;
using Samat.Framework.Domain;
using System.Data;

namespace Samat.Framework.Presistance.EF
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext Context;
        private readonly IEnumerable<IUnitOfWorkInterceptor> _unitOfWorkInterceptors;

        public UnitOfWork(DbContext context,
            IEnumerable<IUnitOfWorkInterceptor> unitOfWorkInterceptors)
        {
            Context = context;
            _unitOfWorkInterceptors = unitOfWorkInterceptors;
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (Context.Database.CurrentTransaction == null)
            {
                await Context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);
                await AfterBeginTransactionAsync(cancellationToken);
            }
        }

        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            await BeforeSaveChangesAsync(cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
            await AfterSaveChangesAsync(cancellationToken);

            //await _domainEventsDispatcher.DispatchEventsAsync();
        }

        public virtual async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (Context.Database.CurrentTransaction == null)
            {
                throw new InvalidOperationException("there is no external transaction");
            }

            await Context.Database.CurrentTransaction.CommitAsync(cancellationToken);
            await AfterCommitTransactionAsync(cancellationToken);
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (Context.Database.CurrentTransaction != null)
            {
                await Context.Database.CurrentTransaction.RollbackAsync(cancellationToken);
                await AfterRollbackTransactionAsync(cancellationToken);
            }
        }

        #region interceptor
        private Task BeforeSaveChangesAsync(CancellationToken cancellationToken)
        {
            return Task.WhenAll(_unitOfWorkInterceptors.Select(c => c.BeforeSaveChangesAsync(cancellationToken)));
        }

        private Task AfterSaveChangesAsync(CancellationToken cancellationToken)
        {
            return Task.WhenAll(_unitOfWorkInterceptors.Select(c => c.AfterSaveChangesAsync(cancellationToken)));
        }

        private Task AfterBeginTransactionAsync(CancellationToken cancellationToken)
        {
            return Task.WhenAll(_unitOfWorkInterceptors.Select(c => c.AfterBeginTransactionAsync(cancellationToken)));
        }


        private Task AfterCommitTransactionAsync(CancellationToken cancellationToken)
        {
            return Task.WhenAll(_unitOfWorkInterceptors.Select(c => c.AfterCommitTransactionAsync(cancellationToken)));
        }

        private Task AfterRollbackTransactionAsync(CancellationToken cancellationToken)
        {
            return Task.WhenAll(_unitOfWorkInterceptors.Select(c => c.AfterRollbackTransactionAsync(cancellationToken)));
        }
        #endregion


    }
}