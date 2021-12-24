namespace Forum.Services.Post
{
    using Forum.Models.Post;
    using Forum.Data.Models;
    using Forum.Data;
    using Forum.Services.User;
    using System.Collections.Generic;
    using System.Linq;

    public class PostService : IPostService
    {
        private readonly ApplicationDbContext data;
        private readonly IUserService userService;
        public PostService(ApplicationDbContext data,
                             IUserService userService)
        {
            this.data = data;
            this.userService = userService;
        }
        public void Create(CreatePostFormModel mdl)
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
        }
        public List<Category> GetCategories()
        {
            var categoriesQuery = data.Categories.AsQueryable();
            var categories = categoriesQuery
                .OrderByDescending(c => c.Id)
                .ToList();
            return categories;
        }
    }
}
