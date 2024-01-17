using exam.business.Exceptions;
using exam.business.Extentions;
using exam.business.Services.Interfaces;
using exam.core.Models;
using exam.core.Models.Repostories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace exam.business.Services.Implementations
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IWebHostEnvironment _env;

        public BlogService(IBlogRepository blogRepository,
                          IWebHostEnvironment env)
        {
            _blogRepository = blogRepository;
            _env = env;
        }
        public async Task CreateAsync(Blog blog)
        {
            if (blog == null)
            {
                throw new NotFoundExceptions();
            }
            if (blog.ImageFile != null)
            {
                if (blog.ImageFile.ContentType != "image/jpeg" && blog.ImageFile.ContentType != "image/png")
                {
                    throw new InvalidContentException("file must be png! or jpeg!", "ImageFile");
                }
                if (blog.ImageFile.Length > 2077698)
                {
                    throw new InvalidImageSizeException("file must be lower than 2 mb!", "ImageFile");
                }
                blog.ImageUrl = blog.ImageFile.SaveFile(_env.WebRootPath, "uploads/blogs");
                blog.UpdatedDate = DateTime.UtcNow;
                blog.CreatedDate = DateTime.UtcNow;
                blog.IsDeleted = false;

                await _blogRepository.CreateAsync(blog);
                await _blogRepository.CommitAsync();


            }
           

        }

        public async Task DeleteAsync(int id)
        {
            var existblog = await _blogRepository.GetByIdAsync(x => x.Id == id);
            if (existblog == null)
            {
                throw new NotFoundExceptions();
            }
            _blogRepository.Delete(existblog);
            await _blogRepository.CommitAsync();
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _blogRepository.GetAllAsync().ToListAsync();
            await _blogRepository.CommitAsync();

        }

        public Task<Blog> GetByIdAsync(int id)
        {
            var existblog = _blogRepository.GetByIdAsync(x => x.Id == id);
            if (existblog == null)
            {
                throw new NotFoundExceptions();
            }
            return existblog;
        }

        public async Task UpdateAsync(Blog blog)
        {
            if (blog == null)
            {
                throw new NotFoundExceptions();
            }
            var exitblog = await _blogRepository.GetByIdAsync(x => x.Id == blog.Id);
            if (exitblog == null)
            {
                throw new NotFoundExceptions();
            }
            if (blog.ImageFile != null)
            {
                if (blog.ImageFile.ContentType != "image/jpeg" && blog.ImageFile.ContentType != "image/png")
                {
                    throw new InvalidContentException("file must be png! or jpeg!", "ImageFile");
                }
                if (blog.ImageFile.Length > 2077698)
                {
                    throw new InvalidImageSizeException("file must be lower than 2 mb!", "ImageFile");
                }
                Helper.DeleteFile(_env.WebRootPath, "uploads/blogs", exitblog.ImageUrl);
                exitblog.ImageUrl = blog.ImageFile.SaveFile(_env.WebRootPath, "uploads/blogs");

            }
            exitblog.Title=blog.Title;
            exitblog.Description=blog.Description;
            exitblog.UpdatedDate = DateTime.UtcNow;
            await _blogRepository.CommitAsync();
        }
    }
}
