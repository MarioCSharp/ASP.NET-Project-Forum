namespace Forum.Controllers
{
    using Forum.Data;
    using Forum.Data.Models;
    using Forum.Models.Post;
    using Forum.Services.User;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    public class PostController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IUserService userService;
        public PostController(ApplicationDbContext data,
                             IUserService userService)
        {
            this.data = data;
            this.userService = userService;
        }
        public IActionResult Create()
        {
            var categoriesQuery = data.Categories.AsQueryable();
            var categories = categoriesQuery
                .OrderByDescending(c => c.Id)
                .ToList();
            return View(new CreatePostFormModel
            {
                Categories = categories
            });
        }
        [HttpPost]
        public IActionResult Create(CreatePostFormModel mdl)
        {
            Post post = new Post
            {
                Tittle = mdl.Tittle,
                Content = mdl.Content,
                UserId = userService.GetUserId(),
                CategoryId = mdl.CategoryId
            };
            data.Posts.Add(post);
            data.SaveChanges();
            return View("Index", "Home");
        }
    }
}
