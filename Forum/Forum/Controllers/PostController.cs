namespace Forum.Controllers
{
    using Forum.Data;
    using Forum.Models.Post;
    using Forum.Services.Post;
    using Forum.Services.User;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using Forum.Models.Comment;
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
            var commentQuery = data.Comments.AsQueryable();
            return View(new PostDetailsViewModel
            {
                Id = post.Id,
                Title = post.Tittle,
                Content = post.Content,
                MyUser = data.Users.FirstOrDefault(x => x.Id == post.UserId),
                Comments = commentQuery.Where(x => x.PostId == post.Id).OrderByDescending(x => x.Id).ToList()
            });
        }
        [Authorize]
        public IActionResult Comment(int Id)
        {
            return View(new CommentFormModel
            {
                PostId = Id,
                UserId = userService.GetUserId()
            });
        }
        [Authorize]
        [HttpPost]
        public IActionResult Comment(CommentFormModel commentInput)
        {
            postService.Comment(commentInput);
            return RedirectToAction("Index", "Home");
        }
    }
}
