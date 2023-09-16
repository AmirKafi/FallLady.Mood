using FallLady.Mood.Application.Contract.Dto.Transactions;
using FallLady.Mood.Utility.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Interfaces.Transactions
{
    public interface ITransactionService
    {
        public Task<ServiceResponse<bool>> Pay(TransactionCreateDto dto);
    }
}
