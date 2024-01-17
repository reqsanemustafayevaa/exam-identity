using exam.business.Exceptions;
using exam.business.Services.Interfaces;
using exam.core.Models;
using Microsoft.AspNetCore.Mvc;

namespace exam.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IActionResult> Index()
        {
            var blogs =await _blogService.GetAllAsync();
            return View(blogs);
           
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }
            try
            {
                await _blogService.CreateAsync(blog);
            }
            catch(NotFoundExceptions ex)
            {
                throw new NotFoundExceptions(ex.Message);
                
                
            }
            catch (InvalidContentException ex)
            {
                throw new InvalidContentException(ex.Message, ex.Propertyname);

            }
            catch(InvalidImageSizeException ex)
            {
                throw new InvalidImageSizeException(ex.Message, ex.Propertyname);
            }
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var exitblog =await  _blogService.GetByIdAsync(id);
            return View(exitblog);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                await _blogService.UpdateAsync(blog);
            }
            catch (NotFoundExceptions ex)
            {
                throw new NotFoundExceptions(ex.Message);

            }
            catch (InvalidContentException ex)
            {
                throw new InvalidContentException(ex.Message, ex.Propertyname);

            }
            catch (InvalidImageSizeException ex)
            {
                throw new InvalidImageSizeException(ex.Message, ex.Propertyname);
            }
            return RedirectToAction("index");
        }
       
    }
}
