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
    public class CommentCrud : Crud<Comment>, ICommentCrud
    {
        public CommentCrud(DataContext context) : base(context)
        {
        }

        public List<Comment> GetAllCommentByInclude()
        {
            return _context.Comments.Include(x => x.AppUser).Include(x => x.BlogPost).ToList();
        }

        public List<Comment> GetAllCommentByInclude(Expression<Func<Comment, bool>> expression)
        {
           return _context.Comments.Include(x => x.AppUser).Include(x => x.BlogPost).Where(expression).ToList();
        }

        public Comment GetCommentByInclude(int id)
        {
            return _context.Comments.Include(x => x.AppUser).Include(x => x.BlogPost).FirstOrDefault(x => x.Id == id);
        }

        public Comment GetCommentByInclude(Expression<Func<Comment, bool>> expression)
        {
            return _context.Comments.Include(x => x.AppUser).Include(x => x.BlogPost).FirstOrDefault(expression);
        }
    }
}