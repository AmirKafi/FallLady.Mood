using FallLady.Mood.Framework.Core.Enum;

namespace FallLady.Mood.Application.Contract.Dto.Orders
{
    public class OrderCreateDto
    {
        public FormEnum OrderType { get; set; }
        public int? CourseId { get; set; }
        public string UserId { get; set; }
        public bool IsPayed { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
