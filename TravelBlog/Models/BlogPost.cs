using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TravelBlog.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Image { get; set; } 

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public City City { get; set; }

        public int AppUserId { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }


        public List<Like> Likes { get; set; }


        public List<Comment> Comments { get; set; }

    }
}