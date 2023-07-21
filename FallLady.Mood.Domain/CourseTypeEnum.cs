using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Domain
{
    public enum CourseTypeEnum
    {
        [Display(Name = "آنلاین")]
        Online = 1,

        [Display(Name = "آفلاین")]
        Offline
    }
}
