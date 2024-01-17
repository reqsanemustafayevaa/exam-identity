using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace exam.core.Models.Repostories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        DbSet<TEntity> Table { get;}
        Task CreateAsync(TEntity entity);
        IQueryable<TEntity> GetAllAsync(Expression<Func<TEntity, bool>>? expression=null, params string[] includes);
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>>? expression=null, params string[] includes);
        void Delete(TEntity entity);
        Task<int> CommitAsync();

       

    }
}
