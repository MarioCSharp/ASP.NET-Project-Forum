namespace Forum.Services.Category
{
    using Data.Models;
    using Forum.Models.Category;
    using System.Collections.Generic;
    public interface ICategoryService
    {
        Category GetCategory(int Id);
        List<PostViewModel> GetCategoryPosts(Category category);
        bool Create(CategoryFormModel categoryInput);
    }
}
