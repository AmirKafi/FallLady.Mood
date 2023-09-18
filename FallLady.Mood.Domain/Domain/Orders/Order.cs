using FallLady.Mood.Domain.Domain.Courses;
using FallLady.Mood.Domain.Domain.Discounts;
using FallLady.Mood.Domain.Domain.Transactions;
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

        public Order(FormEnum orderType, int? courseId, int qty, Int64 price, string userId)
        {
            OrderType = orderType;
            CourseId = courseId;
            Qty = qty;
            Price = price;
            TotalPrice = price * qty;
            UserId = userId;
        }

        public FormEnum OrderType { get; private set; }

        public Course? Course { get; private set; }
        public int? CourseId { get; private set; }
        public string? LicenseKey { get; set; }

        public User User { get; private set; }
        public string? UserId { get; private set; }

        public int Qty { get; private set; }
        public Int64 Price { get; private set; }
        public Int64 TotalPrice { get; private set; }

        public int? TransactionId { get; private set; }
        public Transaction? Transaction { get; private set; }

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

        public Order Pay(int transactionId,string licenseKey)
        {
            this.TransactionId = transactionId;
            this.LicenseKey = licenseKey;

            return this;
        }
        public Order Pay(int transactionId)
        {
            this.TransactionId = transactionId;

            return this;
        }
    }
}
