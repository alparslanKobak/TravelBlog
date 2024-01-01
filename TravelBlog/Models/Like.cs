using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TravelBlog.Models
{
    public class Like
    {
        public int Id { get; set; }

        public int BlogPostId { get; set; }

        [ForeignKey(nameof(BlogPostId))]
        public BlogPost BlogPost { get; set; }

        public int AppUserId { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }

        public bool IsLiked { get; set; }
    }
}