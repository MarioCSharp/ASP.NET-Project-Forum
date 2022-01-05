namespace Forum.Models.Post
{
    using Data.Models;
    using System.Collections.Generic;
    public class PostDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; init; }
        public string Content { get; init; }
        public MyUser MyUser { get; set; }
        public int Likes { get; set; }
        public IEnumerable<CommentsViewModel> Comments { get; init; }
    }
}
