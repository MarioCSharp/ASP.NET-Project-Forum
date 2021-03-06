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
    using Forum.Models.Statistics;
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
            var created = postService.Create(mdl, userService.GetUserId());
            if (!created)
            {
                return BadRequest();
            }
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
                Comments = commentQuery
                .Where(x => x.PostId == post.Id)
                .OrderByDescending(x => x.Id)
                .Select(x => new CommentsViewModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    CreaterEmail = x.CreaterEmail,
                    PostedOn = x.PostedOn
                })
                .ToList(),
                Likes = data.Likes.Where(x => x.PostId == post.Id).Count()
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
            postService.Comment(commentInput, userService.GetUserId());
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public IActionResult Delete(int Id)
        {
            var deleted = postService.Delete(Id);
            if (!deleted)
            {
                return BadRequest();
            }
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public IActionResult Posts()
        {
            var postsQuery = data.Posts.ToList();
            string userId = userService.GetUserId();
            var myPosts = postService.GetPostsView(postsQuery, userId);
            return View(new AllMyPostsQueryModel
            {
                Posts = myPosts
            });
        }
    }
}
