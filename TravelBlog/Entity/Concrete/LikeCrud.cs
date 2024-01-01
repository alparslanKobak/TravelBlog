using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TravelBlog.Entity.Abstract;
using TravelBlog.Models;

namespace TravelBlog.Entity.Concrete
{
    public class LikeCrud : ILikeCrud
    {
        private DataContext _context;

        public LikeCrud(DataContext context)
        {
            _context = context;
        }

        // Bir beğeni ekler
        public bool Add(Like entity)
        {
            _context.Likes.Add(entity);
            return _context.SaveChanges() > 0;
        }

        // Bir blog postu için bir kullanıcının beğenisini ekler
        public void AddLike(int blogPostId, int userId)
        {
            var like = new Like
            {
                BlogPostId = blogPostId,
                AppUserId = userId
            };
            _context.Likes.Add(like);
            _context.SaveChanges();
        }

        // Bir kullanıcının belirli bir blog postu için beğenisini kontrol eder
        public bool IsLiked(int blogPostId, int userId)
        {
            return _context.Likes.Any(l => l.BlogPostId == blogPostId && l.AppUserId == userId);
        }

        // Bir beğeniyi kaldırır
        public void RemoveLike(int blogPostId, int userId)
        {
            var like = _context.Likes.FirstOrDefault(l => l.BlogPostId == blogPostId && l.AppUserId == userId);
            if (like != null)
            {
                _context.Likes.Remove(like);
                _context.SaveChanges();
            }
        }

        // Belirli bir ID'ye sahip beğeniyi siler
        public bool Delete(int id)
        {
            var like = _context.Likes.Find(id);
            if (like != null)
            {
                _context.Likes.Remove(like);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        // Bir Lambda ifadesine göre beğeni getirir
        public Like Get(Expression<Func<Like, bool>> expression)
        {
            return _context.Likes.FirstOrDefault(expression);
        }

        // Tüm beğenileri getirir
        public List<Like> GetAll()
        {
            return _context.Likes.ToList();
        }

        public List<Like> GetAll(Expression<Func<Like, bool>> expression)
        {
            return _context.Likes.Where(expression).ToList();
        }

        public Like GetById(int id)
        {
            return _context.Likes.Find(id);
        }

        // Bir beğeniyi günceller
        public bool Update(Like entity, int id)
        {
            
            var like = _context.Likes.Find(id);
            if (like != null)
            {
                like.BlogPostId = entity.BlogPostId;
                like.AppUserId = entity.AppUserId;
                return _context.SaveChanges() > 0;
            }
            return false;
        }
    }
}