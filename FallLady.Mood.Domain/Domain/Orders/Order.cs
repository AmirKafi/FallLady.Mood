using FallLady.Mood.Domain.Domain.Courses;
using FallLady.Mood.Domain.Domain.Users;
using FallLady.Mood.Framework.Core;
using FallLady.Mood.Framework.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Domain.Domain.Orders
{
    public class Order:EntityId<int>
    {

        public Order(FormEnum orderType,int? courseId,bool isPayed,int qty,decimal price)
        {
            OrderType = orderType;
            CourseId = courseId;
            IsPayed = isPayed;
            Qty = qty;
            Price = price;
            TotalPrice = price * qty;
        }

        public FormEnum OrderType { get; set; }

        public Course? Course { get; set; }
        public int? CourseId { get; set; }

        public User User { get; set; }
        public string? UserId { get; set; }

        public bool IsPayed { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
