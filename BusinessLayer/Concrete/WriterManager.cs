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
    public class WriterManager : IWriterService
    {
        IWriterDal _WriterDal;

        public WriterManager(IWriterDal writerDal)
        {
            _WriterDal = writerDal;
        }
        public List<Writer> GetAll()
        {
            return _WriterDal.List();
        }

        public void Create(Writer writer)
        {
            _WriterDal.Create(writer);
        }
        public void Update(Writer writer)
        {
            _WriterDal.Update(writer);
        }

        public void Delete(Writer writer)
        {

            _WriterDal.Delete(writer);

        }

        public Writer GetById(int id)
        {
            return _WriterDal.GetById(x => x.WriterId == id);
        }
        public Writer GetByFilter(Writer writerData)
        {
            return _WriterDal.GetByFilter(x => x.Mail == writerData.Mail && x.Password == writerData.Password);

        }

        public Writer GetByMail(string mail)
        {
            return _WriterDal.GetByFilter(x => x.Mail == mail);
        }
    }
}