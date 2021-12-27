namespace Forum.Models.Category
{
    using System;
    public class PostViewModel
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public DateTime PostedOn { get; init; }
        public string CreaterEmail { get; init; }
    }
}
