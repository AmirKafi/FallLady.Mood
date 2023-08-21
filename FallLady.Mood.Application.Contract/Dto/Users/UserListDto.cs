using FallLady.Mood.Framework.Core.Enum;
using FallLady.Mood.Utility.Extentions;

namespace FallLady.Mood.Application.Contract.Dto.Users
{
    public class UserListDto:BaseDtoListDto<string>
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public RoleEnum Role { get; set; }
        public string RoleTitle => Role.GetDisplayName();
        public bool IsActive { get; set; }
        public string IsActiveTitle => IsActive ? "فعال" : "غیر فعال";
    }
}
