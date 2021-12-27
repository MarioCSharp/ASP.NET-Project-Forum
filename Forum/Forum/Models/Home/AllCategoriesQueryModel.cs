namespace Forum.Models.Home
{
    using System.Collections.Generic;
    public class AllCategoriesQueryModel
    {
        public IEnumerable<CategoriesViewModel> Categories { get; set; }
        public int CategoriesCount { get; set; }
        public int PostsCount { get; set; }
        public int UsersCount { get; set; }
    }
}
