using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TravelBlog.Entity.Abstract;

namespace TravelBlog.Entity.Concrete
{
    public class Crud<T> : ICrud<T> where T : class, new()
    {
        internal DataContext _context;

        internal DbSet<T> _dbSet;

        public Crud(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public bool Add(T entity)
        {

            _dbSet.Add(entity);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            
            T entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            
            return _dbSet.FirstOrDefault(expression);
        }

        public List<T> GetAll()
        {
           
            return _dbSet.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            
            return _dbSet.Where(expression).ToList();
        }

        public T GetById(int id)
        {
            
            return _dbSet.Find(id);
        }

        public bool Update(T entity, int id)
        {
            
            T updatedEntity = _dbSet.Find(id);
            _context.Entry(updatedEntity).CurrentValues.SetValues(entity);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}