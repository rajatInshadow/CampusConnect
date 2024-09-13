using System.ComponentModel.DataAnnotations;

namespace CampusConnect.Models.Models.ViewModels;

public class LogInViewModel
{
    [Required(ErrorMessage = "Email is Required")]
    [EmailAddress]
    //[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please Enter Valid Email Address")]
    public string Email { get; set; }


    [Required(ErrorMessage = "Passowrd is Required")]
    [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at {2} and max {1} character")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

   
}
