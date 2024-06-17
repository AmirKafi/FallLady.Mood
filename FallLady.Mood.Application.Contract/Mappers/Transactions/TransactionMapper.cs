using FallLady.Mood.Application.Contract.Dto.Transactions;
using FallLady.Mood.Domain.Domain.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Mappers.Transactions
{
    public static class TransactionMapper
    {
        public static Transaction ToModel(this TransactionCreateDto dto)
        {
            return new Transaction(dto.TotalPrice,
                                   dto.PaymentCode,
                                   dto.PaymentResult,
                                   dto.PaymentResultDescription,
                                   dto.DiscountId,
                                   dto.PaymentType,
                                   dto.PaymentState,
                                   dto.ReceiptImage);
        }

        public static List<TransactionListDto> ToDto(this IEnumerable<Transaction>? lst)
        {
            if (lst is null)
                return new List<TransactionListDto>();
            else
                return lst.Select(x => new TransactionListDto()
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    TotalPrice = x.TotalPrice,
                    FileName = x.ReceiptImage,
                    DiscountPrice = x.DiscountPrice,
                    PaymentCode = x.PaymentCode,
                    PaymentResult = x.PaymentResult,
                    PaymentResultDescription = x.PaymentResultDescription,
                    PaymentState = x.State,
                    PaymentType = x.PaymentType,
                    OrdersId = x.Orders.Select(x => x.Id).ToList(),
                    OrdersTitle = string.Join(',', x.Orders.Select(y => y.Course?.Title).ToList())
                }).ToList();
        }
    }
}
