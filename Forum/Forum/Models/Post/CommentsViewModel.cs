namespace Forum.Models.Post
{
    using System;
    public class CommentsViewModel
    {
        public int Id { get; init; }
        public string CreaterEmail { get; init; }
        public DateTime PostedOn { get; init; }
        public string Content { get; init; }
    }
}
