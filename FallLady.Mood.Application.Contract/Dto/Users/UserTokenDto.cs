﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Dto.Users
{
    public class UserTokenDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string AccessToken { get; set; }
    }
}
