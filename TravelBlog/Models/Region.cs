using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlog.Models
{
    public class Region
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public List<City> Cities { get; set; }
    }
}