using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        Context context = new Context();
        DbSet<T> _object;
        public GenericRepository()
        {
            _object = context.Set<T>();
        }

        public void Delete(T Data)
        {
            var deletedEntity=context.Entry(Data); 
            deletedEntity.State = EntityState.Deleted; 
            _object.Remove(Data);
            context.SaveChanges();
        }

        public T GetById(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Create(T Data)
        {
            var adddedEntity=context.Entry(Data);
            adddedEntity.State= EntityState.Added;  
            //_object.Add(Data);
            context.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T Data)
        {
            var updatedEntity=context.Entry(Data);
            updatedEntity.State = EntityState.Modified;   
            context.SaveChanges();
        }

        public T GetByFilter(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }
    }
}
