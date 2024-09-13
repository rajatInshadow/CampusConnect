using System.ComponentModel.DataAnnotations;

namespace CampusConnect.Models.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        //[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please Enter Valid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile number is Required")]
        [Phone]
        [MaxLength(10)]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Please valid mobile number")]
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
        [Compare("Password", ErrorMessage = "Confirm passwords does not matched!")]
        public string ConfirmPassword { get; set; }

    }
}
