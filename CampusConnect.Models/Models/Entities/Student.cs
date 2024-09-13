using System.ComponentModel.DataAnnotations;

namespace CampusConnect.Models.Models.Entities
{
    public class Student
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
