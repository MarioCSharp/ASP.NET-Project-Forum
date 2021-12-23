namespace Forum.Models.Home
{
    using System.Collections.Generic;
    using Data.Models;
    public class AllCategoriesQueryModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}
