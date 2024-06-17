using FallLady.Mood.Domain.Domain.Discounts;
using FallLady.Mood.Domain.Domain.Orders;
using FallLady.Mood.Framework.Core;
using FallLady.Mood.Framework.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Domain.Domain.Transactions
{
    public class Transaction:EntityId<int>
    {
        public Transaction(Int64 totalPrice,
                           string paymentCode,
                           string paymentResult,
                           string paymentResultDescription,
                           int? discountId,
                           PaymentTypesEnum paymentType,
                           PaymentStatesEnum state,
                           string? receiptImage)
        {
            this.TotalPrice = totalPrice;
            this.PaymentCode = paymentCode;
            this.PaymentResultDescription = paymentResultDescription;
            this.PaymentResult = paymentResult;
            this.DiscountId = discountId;
            this.State = state;
            this.PaymentType = paymentType;
            this.ReceiptImage = receiptImage;
        }

        public Int64 TotalPrice { get; set; }
        public Int64 DiscountPrice => this.Discount is null ? 0 : TotalPrice * (this.Discount.Precentage / 100);
        public Int64 PayablePrice => this.TotalPrice - this.DiscountPrice;

        public string PaymentCode { get; set; }
        public string PaymentResult { get; set; }
        public string PaymentResultDescription { get; set; }

        public string? ReceiptImage { get; set; }

        public Discount? Discount { get; set; }
        public int? DiscountId { get; set; }

        public PaymentTypesEnum PaymentType { get; set; } = PaymentTypesEnum.CreditCard;
        public bool? Confirmed { get; set; }
        public PaymentStatesEnum State { get; set; } = PaymentStatesEnum.WaitingForPayment;

        public List<Order> Orders { get; set; }

        public void Confirmation(bool confirm)
        {
            if (confirm)
                this.State = PaymentStatesEnum.PaymentSucceeded;
            else
                this.State = PaymentStatesEnum.PaymentnotConfirmed;

            this.Confirmed = confirm;
        }
        
        public void PaymentFailed()
            => this.State = PaymentStatesEnum.PaymentFailed;

        public void PaymentCanceled()
            => this.State = PaymentStatesEnum.PaymentCanceled;
    }
}
