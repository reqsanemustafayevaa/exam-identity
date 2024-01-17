using exam.core.Models;
using exam.core.Models.Repostories.Interfaces;
using exam.data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace exam.data.Repositories.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
       
        public Microsoft.EntityFrameworkCore.DbSet<TEntity> Table =>_context.Set<TEntity>();

       
        public async Task<int> CommitAsync()
        {
           return await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            Table.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            Table.Remove(entity);
        }

        public  IQueryable<TEntity> GetAllAsync(Expression<Func<TEntity, bool>>? expression, params string[] includes)
        {
            var query=Getquery(includes);
            return expression is not null
                   ? query.Where(expression)
                   : query;
        }

        public Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>>? expression, params string[] includes)
        {
            var query=Getquery(includes);
            return expression is not null
                   ?query.Where(expression).FirstOrDefaultAsync()
                   : query.FirstOrDefaultAsync();
        }
        public IQueryable<TEntity>Getquery(params string[] includes)
        {
            var query = Table.AsQueryable();
           if(includes.Length >0 && includes is not null)
            {
                foreach(var include in includes)
                {
                    query = query.Include(include);
                }
               
            }
            return query;
        }
    }
}
