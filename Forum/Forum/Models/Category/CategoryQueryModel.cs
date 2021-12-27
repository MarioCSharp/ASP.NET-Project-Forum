namespace Forum.Models.Category
{
    using Forum.Data.Models;
    using System.Collections.Generic;
    public class CategoryQueryModel
    {
        public string Name { get; set; }
        public ICollection<PostViewModel> Posts { get; set; }
    }
}
