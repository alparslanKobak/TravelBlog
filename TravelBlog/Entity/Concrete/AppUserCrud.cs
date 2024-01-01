using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TravelBlog.Entity.Abstract;
using TravelBlog.Models;
using System.Data.Entity;

namespace TravelBlog.Entity.Concrete
{
    public class AppUserCrud : Crud<AppUser>, IAppUserCrud
    {
        public AppUserCrud(DataContext context) : base(context)
        {
        }

        public List<AppUser> GetAllUserByInclude()
        {
            return _context.AppUsers.Include(x => x.Role).ToList();
        }

        public List<AppUser> GetAllUserByInclude(Expression<Func<AppUser, bool>> expression)
        {
            return _context.AppUsers.Include(x => x.Role).Where(expression).ToList();
        }

        public AppUser GetUserByInclude(int id)
        {
            return _context.AppUsers.Include(x => x.Role).FirstOrDefault(x => x.Id == id);
        }

        public AppUser GetUserByInclude(Expression<Func<AppUser, bool>> expression)
        {
            return _context.AppUsers.Include(x => x.Role).FirstOrDefault(expression);
        }
    }
}