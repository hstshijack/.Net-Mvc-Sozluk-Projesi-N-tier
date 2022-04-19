using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutServices
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Create(About About)
        {
            _aboutDal.Create(About);
        }

        public void Delete(About About)
        {
            _aboutDal.Delete(About);    
        }

        public List<About> GetAll()
        {
          return _aboutDal.List();
        }

        public About GetById(int id)
        {
            return _aboutDal.GetById(x => x.AboutId == id);
        }

        public void Update(About About)
        {
          _aboutDal.Update(About);  
        }
    }
}
