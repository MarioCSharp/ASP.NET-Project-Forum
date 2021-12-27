namespace Forum.Controllers
{
    using Forum.Data;
    using Forum.Services.User;
    using Microsoft.AspNetCore.Mvc;
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
    }
}
