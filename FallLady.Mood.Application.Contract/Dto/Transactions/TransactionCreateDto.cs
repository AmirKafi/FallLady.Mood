using FallLady.Mood.Domain.Domain.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Dto.Transactions
{
    public class TransactionCreateDto
    {
        public decimal TotalPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal PayablePrice => this.TotalPrice - this.DiscountPrice;

        public string PaymentCode { get; set; }
        public string PaymentResult { get; set; }
        public string PaymentResultDescription { get; set; }

        public int? DiscountId { get; set; }
        public List<int> OrdersId { get; set; }
    }
}
