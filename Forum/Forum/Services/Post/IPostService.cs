namespace Forum.Services.Post
{
    using Forum.Models.Post;
    using System.Collections.Generic;
    using Data.Models;
    using Forum.Models.Comment;
    public interface IPostService
    {
        bool Create(CreatePostFormModel mdl, string userId);
        List<Category> GetCategories();
        Post GetPost(int id);
        void Comment(CommentFormModel commentInput, string userId);
        bool Delete(int Id);
    }
}
