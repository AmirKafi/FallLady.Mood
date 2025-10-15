using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Dto
{
    public class BaseDto
    {
        public int offset { get; set; }
        public int limit { get; set; }
    }
}
