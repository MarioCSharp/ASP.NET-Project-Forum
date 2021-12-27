namespace Forum.Services.Category
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    using Forum.Data;
    using Forum.Models.Category;
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext data;
        public CategoryService(ApplicationDbContext data)
        {
            this.data = data;
        }
        public Category GetCategory(int Id)
        => data.Categories.Find(Id);
        public List<PostViewModel> GetCategoryPosts(Category category)
        => data.Posts
                .Where(x => x.CategoryId == category.Id)
                .Select(x => new PostViewModel
                {
                    Id = x.Id,
                    Title = x.Tittle,
                    CreaterEmail = x.CreaterEmail,
                    PostedOn = x.PostedOn,
                })
                .ToList();
        public bool Create(CategoryFormModel categoryInput)
        {
            if (categoryInput.ImageUrl == null)
            {
                return false;
            }
            if (categoryInput.Name == null)
            {
                return false;
            }
            Category category = new Category
            {
                Name = categoryInput.Name,
                ImageURL = categoryInput.ImageUrl
            };
            data.Categories.Add(category);
            data.SaveChanges();
            return true;
        }
    }
}
