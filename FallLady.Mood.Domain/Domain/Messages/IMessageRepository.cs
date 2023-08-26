using FallLady.Mood.Domain.Domain.Messages;
using FallLady.Mood.Framework.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Domain.Domain.Messages
{
    public interface IMessageRepository : IReadRepository<Message, int>, IWriteRepository<Message, int>, IQueryRepository<Message, int>
    {
    }
}
