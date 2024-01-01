using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TravelBlog.Entity.Abstract
{
    public interface ICrud<T> where T : class
    {

        List<T> GetAll();

        List<T> GetAll(Expression<Func<T, bool>> expression);

        T GetById(int id);

        T Get(Expression<Func<T, bool>> expression);

        bool Add(T entity);

        bool Update(T entity, int id);

        bool Delete(int id);

    }
}
