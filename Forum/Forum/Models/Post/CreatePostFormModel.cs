namespace Forum.Models.Post
{
    using Forum.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class CreatePostFormModel
    {
        [Required]
        public string Tittle { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
