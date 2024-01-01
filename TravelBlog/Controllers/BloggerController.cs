using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlog.Entity.Abstract;
using TravelBlog.Models;

namespace TravelBlog.Controllers
{
   
    public class BloggerController : Controller
    {
        private readonly IBlogPostCrud _blogPostCrud;
        private readonly ICityCrud _cityCrud;

        public BloggerController(IBlogPostCrud blogPostCrud, ICityCrud cityCrud)
        {
            _blogPostCrud = blogPostCrud;
            _cityCrud = cityCrud;
        }

        // GET: Blogger/Index
        public ActionResult Index()
        {
            AppUser user = Session["User"] as AppUser;
           
            List<BlogPost> blogPosts = _blogPostCrud.GetAllBlogPostByInclude(b => b.AppUserId == user.Id);
            return View(blogPosts);
         
        }


        // GET: Blogger/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blogger/Create
        [HttpPost]
        public ActionResult Create(BlogPost collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blogger/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Blogger/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
               

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blogger/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Blogger/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
