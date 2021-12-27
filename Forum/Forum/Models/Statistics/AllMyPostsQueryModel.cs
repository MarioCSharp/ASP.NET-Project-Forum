namespace Forum.Models.Statistics
{
    using System.Collections.Generic;
    public class AllMyPostsQueryModel
    {
        public IEnumerable<PostsListingViewModel> Posts { get; set; }
    }
}
