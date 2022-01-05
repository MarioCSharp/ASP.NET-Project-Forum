namespace Forum.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Like
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserID { get; set; }
        [Required]
        [ForeignKey("Post")]
        public int PostId { get; set; }
        [Required]
        public DateTime LikedOn { get; set; }
    }
}
