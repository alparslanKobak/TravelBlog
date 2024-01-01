using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelBlog.Models;


namespace TravelBlog.Entity.Abstract
{
    public interface IBlogPostCrud : ICrud<BlogPost>
    {
        List<BlogPost> GetAllBlogPostByInclude();
        List<BlogPost> GetAllBlogPostByInclude(Expression<Func<BlogPost, bool>> expression);
        BlogPost GetBlogPostByInclude(int id);
        BlogPost GetBlogPostByInclude(Expression<Func<BlogPost, bool>> expression);
    }
}
