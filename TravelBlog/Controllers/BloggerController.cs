using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly ICommentCrud _commentCrud;
        private readonly ILikeCrud _likeCrud;
        public BloggerController(IBlogPostCrud blogPostCrud, ICityCrud cityCrud, ICommentCrud commentCrud, ILikeCrud likeCrud)
        {
            _blogPostCrud = blogPostCrud;
            _cityCrud = cityCrud;
            _commentCrud = commentCrud;
            _likeCrud = likeCrud;
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
            BlogPost blogPost = _blogPostCrud.GetBlogPostByInclude(id);
            ViewBag.CityId = new SelectList(_cityCrud.GetAll(), "Id", "Name", blogPost.CityId);
            return View(blogPost);
        }

        // POST: Blogger/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BlogPost blogPost, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images/"), fileName);
                    image.SaveAs(path);
                    blogPost.Image = fileName;
                }
                blogPost.AppUserId = (Session["User"] as AppUser).Id;


                _blogPostCrud.Update(blogPost, id);
                return RedirectToAction("Index","Blogger");
            }

            ViewBag.CityId = new SelectList(_cityCrud.GetAll(), "Id", "Name", blogPost.CityId);
            return View(blogPost);
        }

        // GET: Blogger/Delete/5
      

        // POST: Blogger/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                BlogPost blogPost = _blogPostCrud.GetBlogPostByInclude(id);
                if (blogPost == null)
                {
                    // BlogPost bulunamadı, hata mesajı ile birlikte listeye geri dön
                    TempData["Message"] = "<div class='alert alert-danger text-center'>BlogPost not found</div> ";
                    return RedirectToAction("Index");
                }

             
                _blogPostCrud.Delete(blogPost.Id);
                TempData["Message"] = "<div class='alert alert-success text-center'>BlogPost deleted Successfully</div> ";

                return RedirectToAction("Index");
            }
            catch
            {
                // Silme işlemi sırasında hata oluştu, kullanıcıya bilgi ver
                TempData["Message"] = "<div class='alert alert-danger text-center'>Error</div> ";

                return RedirectToAction("Index","Home");
            }
        }
    }
}
