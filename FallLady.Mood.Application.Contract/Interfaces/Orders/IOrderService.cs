using FallLady.Mood.Application.Contract.Dto.Orders;
using FallLady.Mood.Utility.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Interfaces.Orders
{
    public interface IOrderService
    {
        Task<ServiceResponse<List<OrderListDto>>> LoadOrders(string userId);
        Task<ServiceResponse<bool>> AddOrder(OrderCreateDto dto);
        Task<ServiceResponse<bool>> RemoveOrder(int orderId);
        Task<ServiceResponse<bool>> RemoveAllOrders(string userId);
    }
}
