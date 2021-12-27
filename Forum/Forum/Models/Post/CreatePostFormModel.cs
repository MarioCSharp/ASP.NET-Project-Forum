namespace Forum.Models.Post
{
    using Forum.Data.Models;
    using Forum.Models.Home;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class CreatePostFormModel
    {
        [Required]
        public string Tittle { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public ICollection<CategoriesViewModel> Categories { get; set; }
    }
}
