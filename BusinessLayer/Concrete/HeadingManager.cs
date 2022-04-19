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
    public class HeadingManager:IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }
        public List<Heading> GetAll()
        {
            return _headingDal.List();
        }

        public void Create(Heading heading)
        {
            _headingDal.Create(heading);
        }
        public void Update(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public void Delete(Heading heading)
        {
           
            _headingDal.Update(heading);

        }
        public Heading GetById(int id)
        {
            return _headingDal.GetById(x => x.HeadingId == id);
        }

        public List<Heading> GetAllByWriter(int id)
        {
           
            return _headingDal.List(x => x.WriterId == id && x.Status==true);
        }
    }
}
