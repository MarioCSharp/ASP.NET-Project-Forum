namespace Forum.Areas.Administrator.Controllers
{
    using Forum.Data;
    using Forum.Models.Home;
    using Forum.Services.Administrator;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    public class AdministratorController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IAdministratorService administratorService;
        public AdministratorController(ApplicationDbContext data,
                                       IAdministratorService administratorService)
        {
            this.data = data;
            this.administratorService = administratorService;
        }
        public IActionResult Manage()
        {
            return View();
        }
        [Authorize]
        public IActionResult EditCategories()
        {
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
        public IActionResult Delete(int Id)
        {
            administratorService.DeleteCategory(Id);
            return RedirectToAction(nameof(EditCategories));
        }
    }
}
