using FallLady.Mood.Domain.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Persistance.Repositories.Orders
{
    public class OrderRepository:CrudRepository<Order,int>,IOrderRepository
    {
    }
}
