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
    public class RegionCrud : Crud<Region>, IRegionCrud
    {
        public RegionCrud(DataContext context) : base(context)
        {
        }

        public List<Region> GetAllRegionByInclude()
        {
            return _context.Regions.Include(x => x.Cities).ToList();
        }

        public List<Region> GetAllRegionByInclude(Expression<Func<Region, bool>> expression)
        {
            return _context.Regions.Include(x => x.Cities).Where(expression).ToList();
        }

        public Region GetRegionByInclude(int id)
        {
            return _context.Regions.Include(x => x.Cities).FirstOrDefault(x => x.Id == id);
        }

        public Region GetRegionByInclude(Expression<Func<Region, bool>> expression)
        {
            return _context.Regions.Include(x => x.Cities).FirstOrDefault(expression);
        }
    }
}