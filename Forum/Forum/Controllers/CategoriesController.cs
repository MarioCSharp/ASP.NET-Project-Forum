namespace Forum.Controllers
{
    using Forum.Data;
    using Forum.Models.Category;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
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
            var postsCategory = data.Posts
                .Where(x => x.CategoryId == category.Id)
                .ToList();
            return View(new CategoryViewModel
            {
                Name = category.Name,
                Posts = postsCategory
            });
        }
    }
}
