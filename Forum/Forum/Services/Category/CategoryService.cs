namespace Forum.Services.Category
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    using Forum.Data;
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext data;
        public CategoryService(ApplicationDbContext data)
        {
            this.data = data;
        }
        public Category GetCategory(int Id)
        => data.Categories.Find(Id);
        public List<Post> GetCategoryPosts(Category category)
        => data.Posts
                .Where(x => x.CategoryId == category.Id)
                .ToList();
    }
}
