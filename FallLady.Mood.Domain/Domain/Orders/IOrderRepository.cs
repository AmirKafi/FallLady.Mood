using FallLady.Mood.Domain.Domain.Orders;
using FallLady.Mood.Framework.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Domain.Domain.Orders
{
    public interface IOrderRepository : IReadRepository<Order, int>, IWriteRepository<Order, int>, IQueryRepository<Order, int>,IDeleteRepository<Order,int>
    {
    }
}
