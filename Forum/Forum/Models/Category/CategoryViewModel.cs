namespace Forum.Models.Category
{
    using Forum.Data.Models;
    using System.Collections.Generic;
    public class CategoryViewModel
    {
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
