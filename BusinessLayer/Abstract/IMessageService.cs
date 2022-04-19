using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAllInbox(string mail);
        List<Message> GetAllSendBox(string mail);
        void Create(Message message);
        Message GetById(int id);
        void Delete(Message message);
        void Update(Message message);
    }
}
