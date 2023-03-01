using System.ComponentModel.DataAnnotations;

namespace APi.ViewModels
{
    public class AccountEmployeeVM
    {
        [Display(Name = "Email"), MaxLength(50), EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
    }
}

