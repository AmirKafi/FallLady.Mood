using FallLady.Mood.Application.Contract.Dto.Discounts;
using FallLady.Mood.Application.Contract.Interfaces.Discounts;
using FallLady.Mood.Application.Contract.Mappers.Discounts;
using FallLady.Mood.Domain.Domain.Discounts;
using FallLady.Mood.Utility.Extentions.Datetime;
using FallLady.Mood.Utility.ServiceResponse;
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

        public async Task<ServiceResponse<bool>> AddDiscount(DiscountCreateDto dto)
        {
            var result = new ServiceResponse<bool>();

            try
            {
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

        public async Task<ServiceResponse<bool>> CheckDiscountValidation(string code,string? userId,int? courseId)
        {
            var result = new ServiceResponse<bool>();

            try
            {
                var data = _repository.GetQuerable().Where(x => x.Code == code && !x.Expired).FirstOrDefault();


                result.SetData(true);

                if (data is null)
                    result.SetData(false);
                else
                {
                    if (data.ExpireDate.AsDateOnly() < DateTime.Now.AsDateOnly())
                        result.SetData(false);
                    else
                    {
                        if (data.SpecifiedUserId != null && data.SpecifiedUserId != userId)
                            result.SetData(false);
                        if (data.SpecifiedCourseId != null && data.SpecifiedCourseId != courseId)
                            result.SetData(false);
                    }

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
