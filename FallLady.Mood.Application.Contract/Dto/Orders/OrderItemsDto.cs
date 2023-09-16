using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Dto.Orders
{
    public class OrderItemsDto
    {
        public int OrderId { get; set; }
        public string Title { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string PicturePath { get; set; }
    }
}
