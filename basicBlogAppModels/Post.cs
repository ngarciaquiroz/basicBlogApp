
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace basicBlogAppModels
{
    public class Post : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }
        public States WorkflowStates { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public String Approver { get; set; }
    }
}
