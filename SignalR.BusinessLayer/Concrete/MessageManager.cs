using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessage _messageService;

        public MessageManager(IMessage messageService)
        {
            _messageService = messageService;
        }

        public void TAdd(Message entity)
        {
           _messageService.Add(entity);
        }

        public void TDelete(Message entity)
        {
           _messageService.Delete(entity);
        }

        public Message TGetById(int id)
        {
            
            return _messageService.GetById(id); 
        }

        public List<Message> TGetListAll()
        {
            return _messageService.GetListAll();
        }

        public void TUpdate(Message entity)
        {
            _messageService.Update(entity);
        }
    }
}
