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
    public class CityCrud : Crud<City>, ICityCrud
    {
        public CityCrud(DataContext context) : base(context)
        {
        }

        public List<City> GetAllCitiesByInclude()
        {
            return _context.Cities.Include(x => x.Region).Include(x=> x.BlogPosts).ToList();

        }

        public List<City> GetAllCitiesByInclude(Expression<Func<City, bool>> expression)
        {
           return _context.Cities.Include(x => x.Region).Include(x => x.BlogPosts).Where(expression).ToList();
        }

        public City GetCityByInclude(int id)
        {
            return _context.Cities.Include(x => x.Region).Include(x => x.BlogPosts).FirstOrDefault(x => x.Id == id);
        }

        public City GetCityByInclude(Expression<Func<City, bool>> expression)
        {
           return _context.Cities.Include(x => x.Region).Include(x => x.BlogPosts).FirstOrDefault(expression);
        }
    }
}