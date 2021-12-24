namespace Forum.Controllers
{
    using Forum.Data;
    using Forum.Models.Category;
    using Forum.Services.Category;
    using Microsoft.AspNetCore.Mvc;
    using System;
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly ICategoryService categoryService;
        public CategoriesController(ApplicationDbContext data,
                                    ICategoryService categoryService)
        {
            this.data = data;
            this.categoryService = categoryService;
        }
        public IActionResult Category(int Id)
        {
            var category = categoryService.GetCategory(Id);
            var postsCategory = categoryService.GetCategoryPosts(category);
            return View(new CategoryViewModel
            {
                Name = category.Name,
                Posts = postsCategory
            });
        }
    }
}
