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
    public class MessageManager:IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public List<Message> GetAllInbox(string mail)
        {
            return _messageDal.List(x=>x.Receiver==mail);
        }
        public List<Message> GetAllSendBox(string mail)
        {
            return _messageDal.List(x => x.Sender ==mail);
        }
        public void Create(Message message)
        {
            _messageDal.Create(message);
        }
        public void Update(Message message)
        {
            _messageDal.Update(message);
        }

        public void Delete(Message message)
        {

            _messageDal.Delete(message);

        }
        public Message GetById(int id)
        {
            return _messageDal.GetById(x => x.MessageId == id);
        }
    }
}
