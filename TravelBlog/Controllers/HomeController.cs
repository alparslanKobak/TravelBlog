using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlog.Entity;
using TravelBlog.Entity.Abstract;
using TravelBlog.Entity.DbSeeder;
using TravelBlog.Models;

namespace TravelBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogPostCrud _blogPostCrud;

        public HomeController(IBlogPostCrud blogPostCrud)
        {
            _blogPostCrud = blogPostCrud;
        }

        public ActionResult Index()
        {

            IEnumerable<BlogPost> AllBlogPosts = _blogPostCrud.GetAll();

            return View(AllBlogPosts);
        }

        
    }
}