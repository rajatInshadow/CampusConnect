using System.ComponentModel.DataAnnotations;

namespace CampusConnect.Web.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public string Password { get; set; }
    }
}
