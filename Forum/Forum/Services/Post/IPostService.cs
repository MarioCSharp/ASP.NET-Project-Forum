namespace Forum.Services.Post
{
    using Forum.Models.Post;
    using System.Collections.Generic;
    using Data.Models;
    public interface IPostService
    {
        void Create(CreatePostFormModel mdl);
        List<Category> GetCategories();
    }
}
