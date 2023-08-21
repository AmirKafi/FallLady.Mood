using FallLady.Mood.Framework.Core;
using FallLady.Mood.Framework.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using FallLady.Mood.Utility.Extentions;

namespace FallLady.Mood.Domain.Domain.Users
{
    public class User:IdentityUser
    {
        private User()
        {
            
        }
        public User(string userName,
                     string firstName,
                     string lastName,
                     string phoneNumber,
                     RoleEnum role,
                     string email,
                     string password,
                     bool isActive):base(userName)
        {
            base.UserName= userName;
            base.Email = email;
            base.PhoneNumber = phoneNumber;
            base.PasswordHash = password.ToMd5();
            FirstName = firstName;
            LastName= lastName;
            Role = role;
            IsActive= isActive;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RoleEnum Role { get; set; }
        public bool IsActive { get; set; } = true;


        public void Update(string userName,
                           string firstName,
                           string lastName,
                           string phoneNumber,
                           RoleEnum role,
                           string email,
                           bool isActive)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Role = role;
            Email = email;
            IsActive = isActive;
        }

        public void ChangePassword(string password)
        {
            PasswordHash = password.ToMd5();
        }
    }
}
