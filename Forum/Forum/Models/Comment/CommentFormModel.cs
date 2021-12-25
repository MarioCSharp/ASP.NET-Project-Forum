namespace Forum.Models.Comment
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class CommentFormModel
    {
        public int PostId { get; set; }
        public string UserId { get; set; }
        [Required(ErrorMessage = "The content field is required!")]
        [MaxLength(200)]
        public string Content { get; set; }
        [Required]
        public DateTime PostedOn { get; set; }
    }
}
