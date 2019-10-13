using Domain.Entities;

namespace Web.Models
{
    public class IncomingMessageViewModel
    {
        //входящие сообщения
        public IncomingMessage Message { get; set; }

        //Автор сообщения
        public User UserFrom { get; set; }
    }
}