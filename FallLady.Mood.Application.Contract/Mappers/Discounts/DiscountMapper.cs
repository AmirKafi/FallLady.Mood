using FallLady.Mood.Application.Contract.Dto.Discounts;
using FallLady.Mood.Domain.Domain.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Mappers.Discounts
{
    public static class DiscountMapper
    {
        public static Discount ToModel(this DiscountCreateDto dto)
        {
            return new Discount(dto.Code,
                                dto.Amount,
                                dto.Description,
                                dto.SpecifiedUserId,
                                dto.SpecifiedCourseId,
                                dto.ExpireDate);
        }

        public static List<DiscountListDto> ToDto(this IEnumerable<Discount>? model)
        {

            return model.Select(x => new DiscountListDto()
            {
                Id = x.Id,
                Precentage = x.Precentage,
                Code= x.Code,
                CreatedOn= x.CreatedOn,
                Description = x.Description,
                ExpireDate= x.ExpireDate,
                Expired = x.Expired,
                SpecifiedUserFullName = x.SpecifiedUser is null ? null : x.SpecifiedUser.FirstName + " " + x.SpecifiedUser.LastName,
                SpecifiedCourseTitle = x.SpecifiedCourse is null ? null : x.SpecifiedCourse.Title
            }).ToList();
        }
    }
}
