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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public Admin GetByFilter(Admin adminData)
        {
            return _adminDal.GetByFilter(x => x.UserName == adminData.UserName && x.Password == adminData.Password);

        }
        public Admin GetByRoles(string username)
        {
            return _adminDal.GetByFilter(x => x.UserName == username);
        }

    }
}
