﻿using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cotal.Core.Domain;
using Cotal.Core.Domain.Interfaces;
using Cotal.Core.InfacBase.Entities;
using Cotal.Core.InfacBase.Exceptions;
using Cotal.Core.InfacBase.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cotal.Core.InfacBase.Uow
{
    public abstract class UnitOfWorkBase<TContext> : IUnitOfWorkBase where TContext : DbContext
    {
        protected internal UnitOfWorkBase(TContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        protected TContext _context;
        protected readonly IServiceProvider _serviceProvider;

        public IResult SaveChanges()
        {
            CheckDisposed();
            _context.SaveChanges();
            return new CommandResult(true);

        }

        public async Task<IResult> SaveChangesAsync()
        {
            CheckDisposed();
             await _context.SaveChangesAsync();
            return new CommandResult(true);
        }

        public async Task<IResult> SaveChangesAsync(CancellationToken cancellationToken)
        {
            CheckDisposed();
            await _context.SaveChangesAsync(cancellationToken);
            return new CommandResult(true);
        }

        public IRepository<TEntity, TKey> GetRepository<TEntity, TKey>()  
        {
            CheckDisposed();
            var repositoryType = typeof(IRepository<TEntity, TKey>);
            var repository = (IRepository<TEntity, TKey>)_serviceProvider.GetService(repositoryType);
            if (repository == null)
            {
                throw new RepositoryNotFoundException(repositoryType.Name, String.Format("Repository {0} not found in the IOC container. Check if it is registered during startup.", repositoryType.Name));
            }

            ((IRepositoryInjection)repository).SetContext(_context);
            return repository;
        }

        public TRepository GetCustomRepository<TRepository>()
        {
            CheckDisposed();
            var repositoryType = typeof(TRepository);
            var repository = (TRepository)_serviceProvider.GetService(repositoryType);
            if (repository == null)
            {
                throw new RepositoryNotFoundException(repositoryType.Name, String.Format("Repository {0} not found in the IOC container. Check if it is registered during startup.", repositoryType.Name));
            }

            ((IRepositoryInjection)repository).SetContext(_context);
            return repository;
        }

        #region IDisposable Implementation

        protected bool _isDisposed;

        protected void CheckDisposed()
        {
            if (_isDisposed) throw new ObjectDisposedException("The UnitOfWork is already disposed and cannot be used anymore.");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    if (_context != null)
                    {
                        _context.Dispose();
                        _context = null;
                    }
                }
            }
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWorkBase()
        {
            Dispose(false);
        }

        #endregion
    }
}