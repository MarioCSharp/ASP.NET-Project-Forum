namespace Forum.Services.Post
{
    using Forum.Models.Post;
    using System.Collections.Generic;
    using Data.Models;
    using Forum.Models.Comment;
    using Forum.Models.Home;

    public interface IPostService
    {
        bool Create(CreatePostFormModel mdl, string userId);
        List<CategoriesViewModel> GetCategories();
        Post GetPost(int id);
        void Comment(CommentFormModel commentInput, string userId);
        bool Delete(int Id);
    }
}
