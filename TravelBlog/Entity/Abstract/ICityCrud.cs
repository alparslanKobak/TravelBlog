using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelBlog.Models;

namespace TravelBlog.Entity.Abstract
{
    public interface ICityCrud : ICrud<City>
    {
        City GetCityByInclude(int id);

        List<City> GetAllCitiesByInclude();

        City GetCityByInclude(Expression<Func<City, bool>> expression);

        List<City> GetAllCitiesByInclude(Expression<Func<City, bool>> expression);
    }
}
