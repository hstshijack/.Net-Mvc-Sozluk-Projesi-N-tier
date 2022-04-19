using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        void Create(T Data);
        void Delete(T Data);
        void Update(T Data);
        T GetById(Expression<Func<T,bool>>filter);
        T GetByFilter(Expression<Func<T,bool>>filter);
        List<T> List(Expression<Func<T, bool>> filter);
       
    }
}
