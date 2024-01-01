using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TravelBlog.Models
{
    public class AppUser
    {
        public int Id { get; set; }

        public string UserName { get; set; }


        public int RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public AppRole Role { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


        public List<BlogPost> BlogPosts { get; set; }



    }
}