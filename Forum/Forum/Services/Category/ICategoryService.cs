namespace Forum.Services.Category
{
    using Data.Models;
    using System.Collections.Generic;
    public interface ICategoryService
    {
        Category GetCategory(int Id);
        List<Post> GetCategoryPosts(Category category);
    }
}
