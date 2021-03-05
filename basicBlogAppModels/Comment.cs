using basicBlogAppModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace basicBlogAppModels
{
    public class Comment : BaseEntity
    {
        public Comment()
        {
            CommentDate = DateTime.Now;
        }
        [Required]
        public String Author { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        public String Description { get; set; }
        public DateTime CommentDate { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
    }
}
