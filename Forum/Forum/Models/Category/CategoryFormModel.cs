namespace Forum.Models.Category
{
    using System.ComponentModel.DataAnnotations;
    public class CategoryFormModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
