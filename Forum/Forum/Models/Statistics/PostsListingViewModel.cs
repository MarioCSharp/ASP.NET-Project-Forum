namespace Forum.Models.Statistics
{
    using System;
    using Data.Models;
    public class PostsListingViewModel
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Content { get; init; }
        public DateTime PostedOn { get; init; }
        public string CreaterEmail { get; init; }
        public int CategoryId { get; init; }
        public Category Category { get; init; }
    }
}
