using FallLady.Mood.Domain.Domain.Discounts;
using FallLady.Mood.Framework.Core.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Dto.Transactions
{

    public class TransactionCreateDto
    {
        public Int64 TotalPrice { get; set; }
        public Int64 DiscountPrice { get; set; }
        public Int64 PayablePrice => this.TotalPrice - this.DiscountPrice;

        public string PaymentCode { get; set; }
        public string PaymentResult { get; set; }
        public string PaymentResultDescription { get; set; }

        [Display(Name = "رسید بانکی")]
        public string? ReceiptImage { get; set; }
        public IFormFile? ReceiptImageFile { get; set; }

        public int? DiscountId { get; set; }
        public List<int> OrdersId { get; set; }
        public string OrdersStr { get; set; }


        public PaymentTypesEnum PaymentType { get; set; }
        public PaymentStatesEnum PaymentState { get; set; }
    }
}
