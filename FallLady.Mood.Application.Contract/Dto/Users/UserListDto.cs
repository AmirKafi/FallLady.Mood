using FallLady.Mood.Framework.Core.Enum;

namespace FallLady.Mood.Application.Contract.Dto.Users
{
    public class UserListDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public RoleEnum Role { get; set; }
        public string RoleTitle { get; set; }
    }
}
