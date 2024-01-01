using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TravelBlog.Models
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public int RegionId { get; set; }

        [ForeignKey(nameof(RegionId))]
        public Region Region { get; set; }

        public List<BlogPost> BlogPosts { get; set; }
    }
}