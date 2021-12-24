namespace Forum.Controllers
{
    using Forum.Data;
    using Forum.Models.Post;
    using Forum.Services.Post;
    using Forum.Services.User;
    using Microsoft.AspNetCore.Mvc;
    public class PostController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IUserService userService;
        private readonly IPostService postService;
        public PostController(ApplicationDbContext data,
                             IUserService userService,
                             IPostService postService)
        {
            this.data = data;
            this.userService = userService;
            this.postService = postService;
        }
        public IActionResult Create()
        {
            var categories = postService.GetCategories();
            return View(new CreatePostFormModel
            {
                Categories = categories
            });
        }
        [HttpPost]
        public IActionResult Create(CreatePostFormModel mdl)
        {
            postService.Create(mdl);
            return RedirectToAction("Index", "Home");
        }
    }
}
