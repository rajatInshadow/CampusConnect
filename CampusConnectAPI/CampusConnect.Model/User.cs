using CampusConnect.Model.Enums;

namespace CampusConnect.Model
{
    public class Users
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRoles Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
