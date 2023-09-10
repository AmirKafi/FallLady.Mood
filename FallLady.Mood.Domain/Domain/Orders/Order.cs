using FallLady.Mood.Domain.Domain.Courses;
using FallLady.Mood.Domain.Domain.Discounts;
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
    public class Order : EntityId<int>
    {

        public Order(FormEnum orderType, int? courseId, bool isPayed, int qty, decimal price, string userId)
        {
            OrderType = orderType;
            CourseId = courseId;
            IsPayed = isPayed;
            Qty = qty;
            Price = price;
            TotalPrice = price * qty;
            UserId = userId;
        }

        public FormEnum OrderType { get;private set; }

        public Course? Course { get; private set; }
        public int? CourseId { get; private set; }

        public User User { get; private set; }
        public string? UserId { get; private set; }

        public bool IsPayed { get; private set; }
        public int Qty { get; private set; }
        public decimal Price { get; private set; }
        public decimal TotalPrice { get; private set; }
        public decimal PayablePrice => Discount is null ? TotalPrice : TotalPrice - (TotalPrice * (Discount.Precentage / 100));

        public int? DiscountId { get; private set; }
        public Discount? Discount { get; private set; }

        public Order AddToOrderQty()
        {
            Qty += 1;
            TotalPrice = Price * Qty;

            return this;
        }

        public Order RemoveFromOrderQty()
        {
            Qty -= 1;
            TotalPrice = Price * Qty;

            return this;
        }

        public Order SetDiscount(int discountId)
        {
            DiscountId = discountId;
            return this;
        }
    }
}
