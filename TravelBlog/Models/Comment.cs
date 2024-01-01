using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TravelBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public int AppUserId { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }

        public int BlogPostId { get; set; }

        [ForeignKey(nameof(BlogPostId))]
        public BlogPost BlogPost { get; set; }




    }
}