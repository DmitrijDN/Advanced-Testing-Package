
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AdvancedTestingPackage.Models
{
    public class RegistrationViewModel
    {
        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long", MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long", MinimumLength = 3)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "User Role")]
        public int SelectedRole { get; set; }
        public IEnumerable<SelectListItem> UserRoles { get; set; }
    }

}