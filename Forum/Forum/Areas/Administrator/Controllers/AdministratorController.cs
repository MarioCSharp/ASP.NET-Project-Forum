namespace Forum.Areas.Administrator.Controllers
{
    using Forum.Data;
    using Forum.Models.Category;
    using Forum.Models.Home;
    using Forum.Services.Administrator;
    using Forum.Services.Category;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    public class AdministratorController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IAdministratorService administratorService;
        private readonly ICategoryService categoryService;
        public AdministratorController(ApplicationDbContext data,
                                       IAdministratorService administratorService,
                                       ICategoryService categoryService)
        {
            this.data = data;
            this.administratorService = administratorService;
            this.categoryService = categoryService;
        }
        [Authorize]
        public IActionResult Manage()
        {
            if (!User.IsInRole(GlobalConstants.Administator.AdministratorRoleName))
            {
                return RedirectToAction("Error", "Home");
            }
            return View();
        }
        [Authorize]
        public IActionResult EditCategories()
        {
            if (!User.IsInRole(GlobalConstants.Administator.AdministratorRoleName))
            {
                return RedirectToAction("Error", "Home");
            }
            var catoriesQuery = data.Categories.AsQueryable();
            var categories = catoriesQuery
                             .OrderByDescending(x => x.Id)
                             .ToList();
            return View(new AllCategoriesQueryModel
            {
                Categories = categories
            });
        }
        [Authorize]
        public IActionResult DeleteCategory(int Id)
        {
            if (!User.IsInRole(GlobalConstants.Administator.AdministratorRoleName))
            {
                return RedirectToAction("Error", "Home");
            }
            administratorService.DeleteCategory(Id);
            return RedirectToAction(nameof(EditCategories));
        }
        [Authorize]
        public IActionResult DeleteComment(int Id)
        {
            var removed = administratorService.DeleteComment(Id);
            if (!removed)
            {
                return BadRequest();
            }
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public IActionResult EditPosts()
        {
            if (!User.IsInRole(GlobalConstants.Administator.AdministratorRoleName))
            {
                return RedirectToAction("Error", "Home");
            }
            var catoriesQuery = data.Categories.AsQueryable();
            var categories = catoriesQuery
                             .OrderByDescending(x => x.Id)
                             .ToList();
            return View(new AllCategoriesQueryModel
            {
                Categories = categories
            });
        }
        [Authorize]
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
        public IActionResult DeletePost(int Id)
        {
            administratorService.DeletePost(Id);
            return RedirectToAction(nameof(EditPosts));
        }
        [Authorize]
        public IActionResult EditCategory(int Id)
        {
            var categoryToEdit = data.Categories.Find(Id);
            if (categoryToEdit == null)
            {
                return BadRequest();
            }
            return View(new EditCategoryFormModel
            {
                Name = categoryToEdit.Name,
                ImageURL = categoryToEdit.ImageURL
            });
        }
        [Authorize]
        [HttpPost]
        public IActionResult EditCategory(int Id, EditCategoryFormModel toEdit)
        {
            var edited = administratorService.EditCategory(Id, toEdit);
            if (!edited)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(EditCategories));
        }
    }
}
