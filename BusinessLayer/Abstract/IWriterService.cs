using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetAll();
        Writer GetByFilter(Writer writerData);
        Writer GetByMail(string mail);
        void Create(Writer writer);
        Writer GetById(int id);
        void Delete(Writer writer);
        void Update(Writer writer);
    }
}
