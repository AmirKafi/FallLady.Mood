using FallLady.Mood.Application.Contract.Dto.Orders;
using FallLady.Mood.Application.Contract.Interfaces.Orders;
using FallLady.Mood.Application.Contract.Mappers.Orders;
using FallLady.Mood.Domain.Domain.Orders;
using FallLady.Mood.Domain.Domain.Users;
using FallLady.Mood.Utility.ServiceResponse;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Services.Orders
{
    public class OrderService : IOrderService
    {

        #region Constructor
        private readonly IOrderRepository _repository;
        private readonly IMemoryCache _cache;

        public OrderService(IOrderRepository repository, IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        #endregion

        public async Task<ServiceResponse<List<OrderListDto>>> LoadOrders(string userId)
        {
            var result = new ServiceResponse<List<OrderListDto>>();

            try
            {
                var orders = new List<Order>();
                var cache = _cache.Get("UserOrders");
                if (cache != null)
                {
                    result.SetData(_cache.Get<List<OrderListDto>>("UserOrders").Where(x=> x.UserId == userId).ToList());
                }
                else
                {
                    orders = _repository.GetQuerable()
                                        .Include(x => x.Course)
                                        .ThenInclude(x=> x.Teacher)
                                        .Include(x => x.User)
                                        .Where(x => x.UserId == userId && !x.IsPayed)
                                        .ToList();

                    result.SetData(orders.ToDto());
                }
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }
            return result;
        }

        public async Task<ServiceResponse<bool>> AddOrder(OrderCreateDto dto)
        {
            var result = new ServiceResponse<bool>();

            try
            {
                var orders = _repository.GetQuerable()
                                        .Where(x => x.UserId == dto.UserId && !x.IsPayed)
                                        .ToList();

                var model = dto.ToModel();
                if (orders.Any(x => x.UserId == dto.UserId && x.CourseId == dto.CourseId && !x.IsPayed))
                {
                    model = orders.First(x => x.UserId == dto.UserId && x.CourseId == dto.CourseId);
                    model.AddToOrderQty();
                    await _repository.Update(model);
                }
                else
                    await _repository.Add(model);

                orders = _repository.GetQuerable()
                                        .Include(x => x.Course)
                                        .ThenInclude(x => x.Teacher)
                                        .Include(x => x.User)
                                        .Where(x => x.UserId == dto.UserId && !x.IsPayed)
                                        .ToList();

                _cache.Remove("UserOrders");
                _cache.CreateEntry("UserOrders");
                _cache.Set("UserOrders", orders.ToDto());

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }
            return result;
        }

        public async Task<ServiceResponse<bool>> RemoveOrder(int orderId)
        {
            var result = new ServiceResponse<bool>();

            try
            {
                var order = await _repository.Get(orderId);
                if (order is null)
                    throw new Exception("آیتم مورد نظر یافت نشد");

                if (order.Qty > 1)
                {
                    order.RemoveFromOrderQty();
                    await _repository.Update(order);
                }
                else
                    await _repository.Delete(order);


                var orders = _repository.GetQuerable()
                                        .Include(x => x.Course)
                                        .Include(x => x.User)
                                        .Where(x => x.UserId == order.UserId && !x.IsPayed)
                                        .ToList();

                _cache.Remove("UserOrders");
                _cache.CreateEntry("UserOrders");
                _cache.Set("UserOrders", orders.ToDto());

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }
            return result;
        }

        public async Task<ServiceResponse<bool>> RemoveAllOrders(string userId)
        {
            var result = new ServiceResponse<bool>();

            try
            {
                var orders = _repository.GetQuerable().Where(x=> x.UserId == userId && !x.IsPayed).ToList();

                foreach (var item in orders)
                {
                   await _repository.Delete(item);
                }
                _cache.Remove("UserOrders");

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }
            return result;
        }
    }
}
