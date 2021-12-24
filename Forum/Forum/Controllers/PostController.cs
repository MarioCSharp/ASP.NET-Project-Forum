namespace Forum.Controllers
{
    using Forum.Data;
    using Forum.Models.Post;
    using Forum.Services.Post;
    using Forum.Services.User;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using Forum.Data.Models;
    using Forum.Models.Comment;
    using System;

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
                Id = post.Id,
                Title = post.Tittle,
                Content = post.Content,
                MyUser = data.Users.FirstOrDefault(x => x.Id == post.UserId),
                Comments = data.Comments.Where(x => x.PostId == post.Id)
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
            Comment comment = new Comment
            {
                PostId = commentInput.PostId,
                UserId = userService.GetUserId(),
                Content = commentInput.Content,
                PostedOn = DateTime.Now
            };
            data.Comments.Add(comment);
            data.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
