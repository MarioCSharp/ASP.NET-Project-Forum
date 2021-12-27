namespace Forum.Models.Home
{
    using System.Collections.Generic;
    using Data.Models;
    public class AllCategoriesQueryModel
    {
        public IEnumerable<CategoriesViewModel> Categories { get; set; }
    }
}
