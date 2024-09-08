using System.ComponentModel.DataAnnotations;

namespace CampusConnect.Models.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile is Required")]
        [Phone]
        [MaxLength(10)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Type of user is Required")]
        public string UserType { get; set; }

        [Required(ErrorMessage = "Passowrd is Required")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at {2} and max {1} character")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "confirm Passowrd is Required")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at {2} and max {1} character")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
