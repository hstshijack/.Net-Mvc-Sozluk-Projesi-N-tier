using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutServices
    {
        List<About> GetAll();
        void Create(About About);
        About GetById(int id);
        void Delete(About About);
        void Update(About About);
    }
}
