namespace Forum.Services.Post
{
    using Forum.Models.Post;
    using System.Collections.Generic;
    using Data.Models;
    using Forum.Models.Comment;
    public interface IPostService
    {
        void Create(CreatePostFormModel mdl);
        List<Category> GetCategories();
        Post GetPost(int id);
        void Comment(CommentFormModel commentInput);
    }
}
