using FallLady.Mood.Domain.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Persistance.Repositories.Messages
{
    public class MessageRepository:CrudRepository<Message,int>,IMessageRepository
    {
    }
}
