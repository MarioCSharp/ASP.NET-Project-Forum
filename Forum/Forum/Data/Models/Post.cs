namespace Forum.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Post
    {
        public Post()
        {
            this.Comments = new List<Comment>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Tittle { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime PostedOn { get; set; }
        [Required]
        public string CreaterEmail { get; set; }
        [Required]
        [ForeignKey("MyUser")]
        public string UserId { get; set; }
        public virtual MyUser User { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
