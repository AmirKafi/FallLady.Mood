using FallLady.Mood.Application.Contract.Dto.Orders;
using FallLady.Mood.Application.Contract.Interfaces.Orders;
using FallLady.Mood.Utility.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Services.Orders
{
    public class OrderService : IOrderService
    {

        public Task<ServiceResponse<List<OrderListDto>>> LoadOrders(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> AddOrder(OrderCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> RemoveOrder(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
