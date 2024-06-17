using FallLady.Mood.Application.Contract.Dto;
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
        public Task<ServiceResponse<List<TransactionListDto>>> GetTransactions(BaseDto dto);
        public Task<ServiceResponse<bool>> TransactionConfirmation(int transactionId,bool confirm);
        public Task<ServiceResponse<int>> Pay(TransactionCreateDto dto);
    }
}
