using System.ComponentModel.DataAnnotations;

namespace Day9.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Username / Email")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please specify your nationality")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Education level is required")]
        [Display(Name = "Education Level")]
        public string EducationLevel { get; set; }
    }
}

