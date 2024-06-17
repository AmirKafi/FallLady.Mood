using FallLady.Mood.Framework.Core.Enum;
using FallLady.Mood.Utility.Extentions;

namespace FallLady.Mood.Application.Contract.Dto.Transactions
{
    public class TransactionListDto : BaseListDto<int>
    {
        public Int64 TotalPrice { get; set; }
        public Int64 DiscountPrice { get; set; }
        public Int64 PayablePrice => this.TotalPrice - this.DiscountPrice;

        public string PaymentCode { get; set; }
        public string PaymentResult { get; set; }
        public string PaymentResultDescription { get; set; }
        public List<int> OrdersId { get; set; }
        public string OrdersTitle { get; set; }

        public PaymentTypesEnum PaymentType { get; set; }
        public PaymentStatesEnum PaymentState { get; set; }

        public string PaymentTypeTitle => this.PaymentType.GetDisplayName();
        public string PaymentStateTitle => this.PaymentState.GetDisplayName();


        public string? FileName { get; set; }
        public string? FilePath { get; set; }
    }
}
