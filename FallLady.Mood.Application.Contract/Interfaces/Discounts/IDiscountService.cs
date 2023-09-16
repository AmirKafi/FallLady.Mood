using FallLady.Mood.Application.Contract.Dto.Discounts;
using FallLady.Mood.Application.Contract.Dto.Favourites;
using FallLady.Mood.Framework.Core;
using FallLady.Mood.Framework.Core.Enum;
using FallLady.Mood.Utility.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Interfaces.Discounts
{
    public interface IDiscountService
    {
        Task<ServiceResponse<List<DiscountListDto>>> LoadDiscounts(DiscountDto dto);
        Task<ServiceResponse<List<DiscountListDto>>> LoadDiscounts();
        Task<ServiceResponse<List<ComboModel>>> LoadDiscountsAsCombo();
        Task<ServiceResponse<bool>> AddDiscount(DiscountCreateDto dto);
        Task<ServiceResponse<bool>> UpdateExpiration(int discountId,bool expire);
        Task<ServiceResponse<DiscountDetailDto>> GetValidDiscount(string code, string? userId);
    }
}
