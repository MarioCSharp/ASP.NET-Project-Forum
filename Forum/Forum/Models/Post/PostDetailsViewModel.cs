﻿namespace Forum.Models.Post
{
    using Data.Models;
    using System.Collections.Generic;
    public class PostDetailsViewModel
    {
        public string Title { get; init; }
        public string Content { get; init; }
        public IEnumerable<Comment> Comments { get; init; }
    }
}
