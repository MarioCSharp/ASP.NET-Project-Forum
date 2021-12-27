namespace Forum.Controllers
{
    using Forum.Data;
    using Forum.Models.Statistics;
    using Forum.Services.User;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using Forum.Data.Models;
    public class StatisticsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IUserService userService;
        public StatisticsController(ApplicationDbContext context,
                                    IUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }
        [Authorize]
        public IActionResult Posts()
        {
            var postsQuery = context.Posts.AsQueryable();
            var myPosts = postsQuery
                .Where(x => x.UserId == userService.GetUserId())
                .Select(y => new PostsListingViewModel
                {
                    Id = y.Id,
                    Content = y.Content,
                    CreaterEmail = y.CreaterEmail,
                    PostedOn = y.PostedOn,
                    Title = y.Tittle
                })
                .OrderByDescending(x => x.Id)
                .ToList();
            return View(new AllMyPostsQueryModel
            {
                Posts = myPosts
            });
        }
    }
}
