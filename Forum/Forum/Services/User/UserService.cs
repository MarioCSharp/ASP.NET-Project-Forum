using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Forum.Services.User
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor httpContext;
        public UserService(IHttpContextAccessor httpContext)
        {
            this.httpContext = httpContext;
        }
        public string GetUserId()
        {
            return httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
