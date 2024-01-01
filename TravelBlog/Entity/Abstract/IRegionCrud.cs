using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelBlog.Models;

namespace TravelBlog.Entity.Abstract
{
    public interface IRegionCrud : ICrud<Region>
    {
        List<Region> GetAllRegionByInclude();
        List<Region> GetAllRegionByInclude(Expression<Func<Region, bool>> expression);
        Region GetRegionByInclude(int id);
        Region GetRegionByInclude(Expression<Func<Region, bool>> expression);
    }
}
