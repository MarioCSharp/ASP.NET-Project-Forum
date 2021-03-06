namespace Forum.Areas.Administrator.Controllers
{
    using Forum.Data;
    using Forum.Models.Administrator;
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
        [Authorize(Roles = GlobalConstants.Administator.AdministratorRoleName)]
        public IActionResult Manage()
        {
            var isAdmin = IsAdmin();
            if (!isAdmin)
            {
                return RedirectToAction("Error", "Home");
            }
            return View();
        }
        [Authorize(Roles = GlobalConstants.Administator.AdministratorRoleName)]
        public IActionResult EditCategories()
        {
            var catoriesQuery = data.Categories.AsQueryable();
            var categories = catoriesQuery
            .OrderByDescending(x => x.Id)
            .Select(x => new CategoriesViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ImageURL = x.ImageURL
            })
            .ToList();
            return View(new AllCategoriesQueryModel
            {
                Categories = categories
            });
        }
        [Authorize(Roles = GlobalConstants.Administator.AdministratorRoleName)]
        public IActionResult DeleteCategory(int Id)
        {
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
        [Authorize(Roles = GlobalConstants.Administator.AdministratorRoleName)]
        public IActionResult EditPosts()
        {
            var catoriesQuery = data.Categories.AsQueryable();
            var categories = catoriesQuery
                             .OrderByDescending(x => x.Id)
                             .Select(x => new CategoriesViewModel
                             {
                                 Id = x.Id,
                                 Name = x.Name,
                                 ImageURL = x.ImageURL
                             })
                             .ToList();
            return View(new AllCategoriesQueryModel
            {
                Categories = categories
            });
        }
        [Authorize(Roles = GlobalConstants.Administator.AdministratorRoleName)]
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
        public IActionResult DeletePost(int Id)
        {
            administratorService.DeletePost(Id);
            return RedirectToAction(nameof(EditPosts));
        }
        [Authorize(Roles = GlobalConstants.Administator.AdministratorRoleName)]
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
        [Authorize(Roles = GlobalConstants.Administator.AdministratorRoleName)]
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
        [Authorize(Roles = GlobalConstants.Administator.AdministratorRoleName)]
        public IActionResult Users()
        {
            var usersQuery = data.Users.AsQueryable();
            var users = usersQuery
                .OrderByDescending(x => x.Id)
                .Select(x => new UsersViewModel
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Email = x.Email,
                    UserName = x.UserName,
                    NormalizedEmail = x.NormalizedEmail,
                    NormalizedUserName = x.NormalizedUserName,
                    PasswordHash = x.PasswordHash
                })
                .ToList();
            return View(new AllUsersQuery
            {
                Users = users
            });
        }
        [Authorize(Roles = GlobalConstants.Administator.AdministratorRoleName)]
        public IActionResult DeleteUser(string Id)
        {
            var deleted = administratorService.DeleteUser(Id);
            if (!deleted)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Users));
        }
        public bool IsAdmin()
        {
            if (User.IsInRole(GlobalConstants.Administator.AdministratorRoleName))
            {
                return true;
            }
            return false;
        }
    }
}
