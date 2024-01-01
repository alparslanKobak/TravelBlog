using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelBlog.Models;

namespace TravelBlog.Entity.Abstract
{
    public interface IAppUserCrud : ICrud<AppUser>
    {
        AppUser GetUserByInclude(int id);

        List<AppUser> GetAllUserByInclude();

        AppUser GetUserByInclude(Expression<Func<AppUser, bool>> expression);

        List<AppUser> GetAllUserByInclude(Expression<Func<AppUser, bool>> expression);
    }
}
