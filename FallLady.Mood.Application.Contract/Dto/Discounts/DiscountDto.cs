using FallLady.Mood.Utility.Extentions.Datetime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Dto.Discounts
{
    public class DiscountDto:BaseDto
    {
        public string Code{ get; set; }
    }
    public class DiscountListDto : BaseListDto<int>
    {
        public string Code { get; set; }
        public int Precentage { get; set; }
        public string Description { get; set; }
        public string? SpecifiedUserFullName { get; set; }
        public string? SpecifiedCourseTitle { get; set; }
        public DateOnly? ExpireDate { get; set; }
        public string ExpireDateLocal => ExpireDate.AsDateTime().ToFa();
        public bool Expired { get; set; }
        public bool IsExpired => ExpireDate is null ? Expired ? false : true
                                                            :
                                                              ExpireDate < DateTime.Now.Date.AsDateOnly() ? Expired ? false : true
                                                                                                          : false;
        public string ExpirationTitle => IsExpired ? "غیر فعال" : "فعال";
    }

    public class DiscountCreateDto
    {
        public string Code { get; set; }
        public int Precentage { get; set; }
        public string? Description { get; set; }

        public bool IsSpecifiedByUser { get; set; }
        public string? SpecifiedUserId { get; set; }

        public bool IsSpecifiedByCourse { get; set; }
        public int? SpecifiedCourseId { get; set; }

        public DateOnly? ExpireDate { get; set; }
    }
}
