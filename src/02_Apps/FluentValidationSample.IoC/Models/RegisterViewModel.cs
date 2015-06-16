using System.ComponentModel.DataAnnotations;

namespace FluentValidationSample.WebApp.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        public bool Validated { get; set; }
    }
}