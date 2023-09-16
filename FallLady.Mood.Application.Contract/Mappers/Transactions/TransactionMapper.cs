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
                                   dto.DiscountId);
        }
    }
}
