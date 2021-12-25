namespace Forum.Controllers
{
    using Forum.Data;
    using Forum.Models.Category;
    using Forum.Models.Home;
    using Forum.Services.Category;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

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
            categoryService.Create(categoryInput);
            return RedirectToAction("EditCategories", "Administrator");
        }
        
    }
}
