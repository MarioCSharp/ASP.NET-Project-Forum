namespace Forum.Controllers
{
    using Forum.Services.Like;
    using Forum.Services.User;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    public class LikeController : Controller
    {
        private readonly IUserService userService;
        private readonly ILikeService likeService;
        public LikeController(IUserService userService,
                              ILikeService likeService)
        {
            this.userService = userService;
            this.likeService = likeService;
        }
        [Authorize]
        public IActionResult Like(int Id)
        {
            string userId = userService.GetUserId();
            likeService.Like(Id, userId);
            return RedirectToAction("Details", "Post", new {Id = Id});
        }
    }
}
