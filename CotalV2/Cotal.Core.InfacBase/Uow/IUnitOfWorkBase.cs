using System;
using System.Threading;
using System.Threading.Tasks;
using Cotal.Core.Domain.Interfaces;
using Cotal.Core.InfacBase.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cotal.Core.InfacBase.Uow
{
    public interface IUnitOfWorkBase : IDisposable
    {
        IResult SaveChanges();
        Task<IResult> SaveChangesAsync();
        Task<IResult> SaveChangesAsync(CancellationToken cancellationToken);  
        IRepository<TEntity, TKey> GetRepository<TEntity, TKey>();
        TRepository GetCustomRepository<TRepository>();
    }
}