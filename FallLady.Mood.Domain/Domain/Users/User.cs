using FallLady.Mood.Framework.Core;
using FallLady.Mood.Framework.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Domain.Domain.Users
{
    public class User:EntityId<int>
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
                     bool isActive)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Role = role;
            Email = email;
            Password = password;
            IsActive = isActive;
        }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RoleEnum Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
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
            Password = password;
        }
    }
}
