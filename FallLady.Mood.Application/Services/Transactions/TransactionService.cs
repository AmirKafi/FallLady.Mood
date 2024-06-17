using FallLady.Mood.Application.Contract.Dto;
using FallLady.Mood.Application.Contract.Dto.Transactions;
using FallLady.Mood.Application.Contract.Interfaces.Transactions;
using FallLady.Mood.Application.Contract.Mappers.Transactions;
using FallLady.Mood.Domain.Domain.Orders;
using FallLady.Mood.Domain.Domain.Transactions;
using FallLady.Mood.Utility.ServiceResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Services.Transactions
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;
        private readonly IOrderRepository _orderRepository;

        public TransactionService(ITransactionRepository repository, IOrderRepository orderRepository)
        {
            _repository = repository;
            _orderRepository = orderRepository;
        }

        public async Task<ServiceResponse<List<TransactionListDto>>> GetTransactions(BaseDto dto)
        {
            var result = new ServiceResponse<List<TransactionListDto>>();

            try
            {
                var orders =await _repository.GetList(dto.offset,dto.limit);

                result.SetData(orders.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> TransactionConfirmation(int transactionId,bool confirm)
        {
            var result = new ServiceResponse<bool>();

            try
            {
                var order =await _repository.Get(transactionId);

                if (order is null)
                    result.SetException("پرداخت مورد نظر یافت نشد");

                order?.Confirmation(confirm);

                await _repository.Update(order);

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }

            return result;
        }

        public async Task<ServiceResponse<int>> Pay(TransactionCreateDto dto)
        {
            var result = new ServiceResponse<int>();

            try
            {
                var orders = _orderRepository.GetQuerable().AsNoTracking().Where(x => dto.OrdersId.Contains(x.Id)).ToList();

                var model = dto.ToModel();

                await _repository.Add(model);

                result.SetData(model.Id);
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }

            return result;
        }
    }
}
