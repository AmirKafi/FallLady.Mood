using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Dto.Users
{
    public class UserLoginDto
    {
        [Display(Name = "نام کاربری")]
        public string UserName { get; set;}

        [Display(Name = "کلمه عبور")]
        public string Password { get; set;}
    }
}
