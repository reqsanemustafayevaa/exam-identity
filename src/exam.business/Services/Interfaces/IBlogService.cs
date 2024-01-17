using exam.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace exam.business.Services.Interfaces
{
    public interface IBlogService
    {
        Task CreateAsync(Blog blog);
        Task UpdateAsync(Blog blog);
        Task<Blog> GetByIdAsync(int id);
        Task<List<Blog>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
