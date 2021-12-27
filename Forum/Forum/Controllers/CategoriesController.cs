namespace Forum.Controllers
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
        [Authorize(Roles = GlobalConstants.Administator.AdministratorRoleName)]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = GlobalConstants.Administator.AdministratorRoleName)]
        [HttpPost]
        public IActionResult Create(CategoryFormModel categoryInput)
        {
            var created = categoryService.Create(categoryInput);
            if (!created)
            {
                return BadRequest();
            }
            return RedirectToAction("EditCategories", "Administrator");
        }
        
    }
}
