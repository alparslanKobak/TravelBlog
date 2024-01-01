using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlog.Models;

namespace TravelBlog.Entity.Abstract
{
    public interface ICommentCrud : ICrud<Comment> 
    {
        List<Comment> GetAllCommentByInclude();
        List<Comment> GetAllCommentByInclude(System.Linq.Expressions.Expression<Func<Comment, bool>> expression);
        Comment GetCommentByInclude(int id);
        Comment GetCommentByInclude(System.Linq.Expressions.Expression<Func<Comment, bool>> expression);
    }
}
