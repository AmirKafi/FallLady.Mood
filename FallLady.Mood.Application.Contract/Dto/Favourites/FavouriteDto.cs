using FallLady.Mood.Framework.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Dto.Favourites
{
    public class FavouriteDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public FormEnum Disclaimer { get; set; }
        public int? CourseId { get; set; }
        public int? TeacherId { get; set; }
        public int? BlogId { get; set; }
    }
}
