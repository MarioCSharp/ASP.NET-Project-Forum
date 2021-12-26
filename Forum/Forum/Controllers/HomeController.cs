namespace Forum.Controllers
{
    using Forum.Data;
    using Forum.Models;
    using Forum.Models.Home;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Diagnostics;
    using System.Linq;
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext data;
        public HomeController(ILogger<HomeController> logger,
                              ApplicationDbContext data)
        {
            _logger = logger;
            this.data = data;
        }
        public IActionResult Index()
        {
            var dataQuery = data.Categories.AsQueryable();
            var list = dataQuery
                .OrderByDescending(x => x.Id);
            return View(new AllCategoriesQueryModel
            {
                Categories = dataQuery
            });
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
