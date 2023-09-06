using FallLady.Mood.Application.Contract.Dto.Course;
using FallLady.Mood.Application.Contract.Dto.Orders;
using FallLady.Mood.Application.Contract.Mappers.Courses;
using FallLady.Mood.Domain.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Mappers.Orders
{
    public static class OrderMapper
    {
        public static Order ToModel(this OrderCreateDto dto)
        {
            return new Order(dto.OrderType,
                             dto.CourseId,
                             dto.IsPayed,
                             dto.Qty,
                             dto.Price);
        }

        public static List<OrderListDto> ToDto(this List<Order> model)
        {
            return model.Select(x => new OrderListDto()
            {
                Id = x.Id,
                CreatedOn = x.CreatedOn,
                IsPayed = x.IsPayed,
                OrderType = x.OrderType,
                Price = x.Price,
                UserId = x.UserId,
                Qty = x.Qty,
                TotalPrice = x.TotalPrice,
                UserFullName = x.User.FirstName + " " + x.User.LastName,
                Course = x.Course is null ? new CourseDetailsDto() : x.Course.ToDetailDto()
            }).ToList();
        }
    }
}
