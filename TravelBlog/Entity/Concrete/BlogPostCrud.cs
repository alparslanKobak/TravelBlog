using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TravelBlog.Entity.Abstract;
using TravelBlog.Models;
using System.Data.Entity;

namespace TravelBlog.Entity.Concrete
{
    public class BlogPostCrud : Crud<BlogPost>, IBlogPostCrud
    {
        public BlogPostCrud(DataContext context) : base(context)
        {
        }

        public List<BlogPost> GetAllBlogPostByInclude()
        {
            return _context.BlogPosts.Include(x=> x.City).Include(x=> x.AppUser).Include(x => x.Comments).Include(x => x.Comments.Select(c => c.AppUser)).Include(x=> x.Likes).ToList();
        }

        public List<BlogPost> GetAllBlogPostByInclude(Expression<Func<BlogPost, bool>> expression)
        {
            return _context.BlogPosts.Include(x => x.City).Include(x => x.AppUser).Include(x=> x.Comments).Include(x => x.Comments.Select(c => c.AppUser)).Include(x => x.Likes).Where(expression).ToList();
        }

        public BlogPost GetBlogPostByInclude(int id)
        {
           return _context.BlogPosts.Include(x => x.City).Include(x => x.AppUser).Include(x => x.Comments).Include(x => x.Comments.Select(c => c.AppUser)).Include(x => x.Comments.Select(c => c.AppUser)).Include(x => x.Likes).FirstOrDefault(x => x.Id == id);
        }

        public BlogPost GetBlogPostByInclude(Expression<Func<BlogPost, bool>> expression)
        {
           return _context.BlogPosts.Include(x => x.City).Include(x => x.AppUser).Include(x => x.Comments).Include(x => x.Comments.Select(c => c.AppUser)).Include(x => x.Likes).FirstOrDefault(expression);
        }
    }
}