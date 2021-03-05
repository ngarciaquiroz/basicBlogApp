using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace basicBlogApp.Models
{
    public class PostViewModel
    {
        [Required]
        public String Content { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }
        public String Approver { get; set; }
        public int ID { get; set; }
    }
}
