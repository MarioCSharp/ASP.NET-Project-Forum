namespace Forum.Controllers
{
    using Forum.Data;
    using Forum.Models.Post;
    using Forum.Services.Post;
    using Forum.Services.User;
    using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult Create()
        {
            var categories = postService.GetCategories();
            return View(new CreatePostFormModel
            {
                Categories = categories
            });
        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(CreatePostFormModel mdl)
        {
            postService.Create(mdl);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Details(int Id)
        {
            var post = postService.GetPost(Id);
            return View(new PostDetailsViewModel
            {
                Title = post.Tittle,
                Content = post.Content,
                Comments = post.Comments
            });
        }
    }
}
