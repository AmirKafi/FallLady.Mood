using FallLady.Mood.Application.Contract.Dto.Discounts;
using FallLady.Mood.Application.Contract.Interfaces.Discounts;
using FallLady.Mood.Application.Contract.Mappers.Discounts;
using FallLady.Mood.Domain.Domain.Discounts;
using FallLady.Mood.Framework.Core;
using FallLady.Mood.Utility.Extentions.Datetime;
using FallLady.Mood.Utility.ServiceResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Services.Discounts
{
    public class DiscountService : IDiscountService
    {
        #region Constructor
        private readonly IDiscountRepository _repository;

        public DiscountService(IDiscountRepository repository)
        {
            _repository = repository;
        }
        #endregion

        public async Task<ServiceResponse<List<DiscountListDto>>> LoadDiscounts(DiscountDto dto)
        {
            var result = new ServiceResponse<List<DiscountListDto>>();

            try
            {
                var data = await _repository.GetList(dto.offset, dto.limit);

                result.SetData(data.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }

            return result;
        }

        public async Task<ServiceResponse<List<DiscountListDto>>> LoadDiscounts()
        {
            var result = new ServiceResponse<List<DiscountListDto>>();

            try
            {
                var data = await _repository.GetQuerable().ToListAsync();

                result.SetData(data.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }

            return result;
        }

        public async Task<ServiceResponse<List<ComboModel>>> LoadDiscountsAsCombo()
        {
            var result = new ServiceResponse<List<ComboModel>>();

            try
            {
                var data =await _repository.GetQuerable().ToListAsync();

                result.SetData(data.ToCombo());
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> AddDiscount(DiscountCreateDto dto)
        {
            var result = new ServiceResponse<bool>();

            try
            {
                var exist = _repository.GetQuerable().Any(x => dto.Code == dto.Code);

                if (exist)
                    throw new Exception("کد تخفیف وارد شده تکراری می باشد");

                await _repository.Add(dto.ToModel());

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> UpdateExpiration(int discountId, bool expire)
        {
            var result = new ServiceResponse<bool>();

            try
            {
                var data = _repository.GetQuerable().Where(x => x.Id == discountId).FirstOrDefault();

                data.UpdateExpiration(expire);

                await _repository.Update(data);

                result.SetData(true);
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }

            return result;
        }

        public async Task<ServiceResponse<DiscountDetailDto>> GetValidDiscount(string code, string? userId)
        {
            var result = new ServiceResponse<DiscountDetailDto>();

            try
            {
                var data = _repository.GetQuerable().Where(x => x.Code == code && (x.SpecifiedUserId == null || x.SpecifiedUserId == userId)).FirstOrDefault();
                if (data is null)
                    result.SetException("کد تخفیف مورد نظر یافت نشد");
                else
                {
                    var res = data.ToDto();

                    if (res.IsExpired)
                        result.SetException("کد تخفیف مورد نظر منقضی شده");
                    else
                        result.SetData(res);
                }
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }

            return result;
        }
    }
}
