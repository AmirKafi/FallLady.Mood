using FallLady.Mood.Domain.Domain.Discounts;
using FallLady.Mood.Domain.Domain.Orders;
using FallLady.Mood.Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Domain.Domain.Transactions
{
    public class Transaction:EntityId<int>
    {
        public Transaction(Int64 totalPrice,string paymentCode,string paymentResult,string paymentResultDescription,int? discountId)
        {
            this.TotalPrice = totalPrice;
            this.PaymentCode = paymentCode;
            this.PaymentResultDescription = paymentResultDescription;
            this.PaymentResult = paymentResult;
            this.DiscountId = discountId;
        }

        public Int64 TotalPrice { get; set; }
        public Int64 DiscountPrice => this.Discount is null ? 0 : TotalPrice * (this.Discount.Precentage / 100);
        public Int64 PayablePrice => this.TotalPrice - this.DiscountPrice;

        public string PaymentCode { get; set; }
        public string PaymentResult { get; set; }
        public string PaymentResultDescription { get; set; }

        public Discount? Discount { get; set; }
        public int? DiscountId { get; set; }

    }
}
