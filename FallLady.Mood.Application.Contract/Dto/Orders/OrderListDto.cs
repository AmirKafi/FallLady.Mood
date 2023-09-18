using FallLady.Mood.Application.Contract.Dto.Course;
using FallLady.Mood.Framework.Core.Enum;
using FallLady.Mood.Utility.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Dto.Orders
{
    public class OrderListDto:BaseListDto<int>
    {
        public FormEnum OrderType { get; set; }
        public string? OrderTypeTitle => OrderType.GetDisplayName();

        public CourseDetailsDto Course { get; set; }
        public string? LicenseKey { get; set; }
        public string UserId { get; set; }
        public string UserFullName { get; set; }

        public bool IsPayed { get; set; }

        public int Qty { get; set; }
        public Int64 Price { get; set; }
        public Int64 TotalPrice { get; set; }
    }
}
