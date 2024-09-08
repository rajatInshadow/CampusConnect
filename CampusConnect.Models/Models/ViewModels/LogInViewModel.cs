using System.ComponentModel.DataAnnotations;

namespace CampusConnect.Models.Models.ViewModels;

public class LogInViewModel
{
    [Required(ErrorMessage = "Email is Required")]
    [EmailAddress]
    public string Email { get; set; }


    [Required(ErrorMessage = "Passowrd is Required")]
    [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at {2} and max {1} character")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Type of user is Required")]
    public string UserType { get; set; }
}
