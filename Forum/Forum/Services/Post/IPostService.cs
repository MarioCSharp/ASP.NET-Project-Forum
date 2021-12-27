namespace Forum.Services.Post
{
    using Forum.Models.Post;
    using System.Collections.Generic;
    using Data.Models;
    using Forum.Models.Comment;
    using Forum.Models.Home;
    using Forum.Models.Statistics;
    public interface IPostService
    {
        bool Create(CreatePostFormModel mdl, string userId);
        List<CategoriesViewModel> GetCategories();
        Post GetPost(int id);
        void Comment(CommentFormModel commentInput, string userId);
        bool Delete(int Id);
        List<PostsListingViewModel> GetPostsView(List<Post> postsQuery, string userId);
    }
}
