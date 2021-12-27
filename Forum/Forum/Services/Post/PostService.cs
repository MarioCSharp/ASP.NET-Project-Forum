namespace Forum.Services.Post
{
    using Forum.Models.Post;
    using Forum.Data.Models;
    using Forum.Data;
    using System.Collections.Generic;
    using System.Linq;
    using Forum.Models.Comment;
    using System;
    using Forum.Models.Home;

    public class PostService : IPostService
    {
        private readonly ApplicationDbContext data;
        public PostService(ApplicationDbContext data)
        {
            this.data = data;
        }
        public bool Create(CreatePostFormModel mdl, string userId)
        {
            if (mdl.Tittle == null || mdl.Content == null || mdl.CategoryId <= 0)
            {
                return false;
            }
            Post post = new Post
            {
                Tittle = mdl.Tittle,
                Content = mdl.Content,
                PostedOn = DateTime.Now,
                CreaterEmail = data.Users.FirstOrDefault(x => x.Id == userId).Email,
                UserId = userId,
                CategoryId = mdl.CategoryId
            };
            data.Posts.Add(post);
            data.SaveChanges();
            return true;
        }
        public List<CategoriesViewModel> GetCategories()
        {
            var categoriesQuery = data.Categories.AsQueryable();
            var categories = categoriesQuery
                .OrderByDescending(c => c.Id)
                .Select(x => new CategoriesViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageURL = x.ImageURL
                })
                .ToList();
            return categories;
        }
        public Post GetPost(int Id)
        => data.Posts.Find(Id);
        public void Comment(CommentFormModel commentInput, string userId)
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
                UserId = userId,
                CreaterEmail = data.Users.FirstOrDefault(x => x.Id == userId).Email,
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
