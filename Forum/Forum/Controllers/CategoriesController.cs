﻿namespace Forum.Controllers
{
    using Forum.Models.Category;
    using Forum.Services.Category;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IActionResult Category(int Id)
        {
            var category = categoryService.GetCategory(Id);
            var postsCategory = categoryService.GetCategoryPosts(category);
            return View(new CategoryQueryModel
            {
                Name = category.Name,
                Posts = postsCategory
            });
        }
        [Authorize]
        public IActionResult Create()
        {
            if (!User.IsInRole(GlobalConstants.Administator.AdministratorRoleName))
            {
                return RedirectToAction("Error", "Home");
            }
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(CategoryFormModel categoryInput)
        {
            if (!User.IsInRole(GlobalConstants.Administator.AdministratorRoleName))
            {
                return RedirectToAction("Error", "Home");
            }
            var created = categoryService.Create(categoryInput);
            if (!created)
            {
                return BadRequest();
            }
            return RedirectToAction("EditCategories", "Administrator");
        }
        
    }
}
