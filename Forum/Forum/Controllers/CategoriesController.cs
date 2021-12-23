namespace Forum.Controllers
{
    using Forum.Data;
    using Forum.Models.Category;
    using Microsoft.AspNetCore.Mvc;
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext data;
        public CategoriesController(ApplicationDbContext data)
        {
            this.data = data;
        }
        public IActionResult Category(int Id)
        {
            var category = data.Categories.Find(Id);
            return View(new CategoryViewModel
            {
                Name = category.Name
            });
        }
    }
}
