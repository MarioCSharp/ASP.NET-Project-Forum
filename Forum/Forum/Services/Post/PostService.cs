namespace Forum.Services.Post
{
    using Forum.Models.Post;
    using Forum.Data.Models;
    using Forum.Data;
    using Forum.Services.User;
    using System.Collections.Generic;
    using System.Linq;
    using Forum.Models.Comment;
    using System;

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
                PostedOn = DateTime.Now,
                CreaterEmail = data.Users.FirstOrDefault(x => x.Id == userService.GetUserId()).Email,
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
        public Post GetPost(int Id)
        => data.Posts.Find(Id);
        public void Comment(CommentFormModel commentInput)
        {
            if (commentInput.PostId <= 0)
            {
                return;
            }
            if (commentInput.Content == null)
            {
                return;
            }
            Post post = data.Posts.Find(commentInput.PostId);
            if (post == null)
            {
                return;
            }
            Comment comment = new Comment
            {
                PostId = commentInput.PostId,
                UserId = userService.GetUserId(),
                CreaterEmail = data.Users.FirstOrDefault(x => x.Id == userService.GetUserId()).Email,
                Content = commentInput.Content,
                PostedOn = DateTime.Now
            };
            data.Comments.Add(comment);
            data.SaveChanges();
        }
        public bool Delete(int Id)
        {
            var post = data.Posts.Find(Id);
            if (post == null)
            {
                return false;
            }
            data.Posts.Remove(post);
            data.SaveChanges();
            return true;
        }
    }
}
