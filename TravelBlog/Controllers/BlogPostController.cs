using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlog.Entity.Abstract;
using TravelBlog.Models;

namespace TravelBlog.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly IBlogPostCrud _blogPostCrud;
        private readonly ICommentCrud _commentCrud;
        private readonly ILikeCrud _likeCrud;

        public BlogPostController(IBlogPostCrud blogPostCrud, ICommentCrud commentCrud, ILikeCrud likeCrud)
        {
            _blogPostCrud = blogPostCrud;
            _commentCrud = commentCrud;
            _likeCrud = likeCrud;
        }

        public ActionResult Details(int id)
        {
            BlogPost blogPost = _blogPostCrud.GetBlogPostByInclude(id);
           
            return View(blogPost);
        }

        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            AppUser user = Session["User"] as AppUser;
            if (user == null)
            {
                TempData["Message"] = "<div class='alert alert-danger text-center'>Please Login First</div> ";
                return RedirectToAction("Login", "Auth");
            }

            comment.AppUserId = user.Id;
            _commentCrud.Add(comment);



            return RedirectToAction(nameof(Details), "BlogPost", new { id = comment.BlogPostId });
        }

        [HttpPost]
        public ActionResult AddLike(Like like)
        {
            AppUser user = Session["User"] as AppUser;
            // Eğer kullanıcı giriş yapmamışsa, giriş sayfasına yönlendir
            if (user == null)
            {
                TempData["Message"] = "<div class='alert alert-danger text-center'>Please Login First</div> ";
                return RedirectToAction("Login", "Auth");
            }

            like.AppUserId = user.Id; // Giriş yapan kullanıcının ID'sini ayarla

            // Kullanıcının daha önce beğenip beğenmediğini kontrol et
            Like existingLike = _likeCrud.Get(l => l.BlogPostId == like.BlogPostId && l.AppUserId == user.Id);

            if (existingLike != null)
            {
                // Kullanıcı daha önce beğenmişse, beğeniyi kaldır
                _likeCrud.Delete(existingLike.Id);
                TempData["Message"] = "<div class='alert alert-success text-center'>Like removed successfully</div> ";
            }
            else
            {
                // Kullanıcı daha önce beğenmemişse, yeni beğeni ekle
                like.IsLiked = true; // Beğeni olarak ayarla
                _likeCrud.Add(like);
                TempData["Message"] = "<div class='alert alert-success text-center'>Liked successfully</div> ";
            }

            // Aynı sayfaya geri dön
            return RedirectToAction(nameof(Details), "BlogPost", new { id = like.BlogPostId });
        }


       
    }
}
