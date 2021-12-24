namespace Forum.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }
        [ForeignKey("MyUser")]
        public string UserId { get; set; }
        public MyUser User { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime PostedOn { get; set; }
    }
}
