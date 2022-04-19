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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public List<Contact> GetAll()
        {
            return _contactDal.List();
        }

        public void Create(Contact contact)
        {
            _contactDal.Create(contact);
        }
        public void Update(Contact contact)
        {
            _contactDal.Update(contact);
        }

        public void Delete(Contact contact)
        {

            _contactDal.Delete(contact);

        }
        public Contact GetById(int id)
        {
            return _contactDal.GetById(x => x.ContactId == id);
        }

    }
}
