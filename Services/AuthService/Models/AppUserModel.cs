using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RampedUp.Services.AuthService.Models
{
    public class AppUserModel
    {
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
      //  [EmailAddress(ErrorMessage = null, ErrorMessageResourceName = "EmailNotValidFormat", ErrorMessageResourceType = typeof(RampedUp.Resources.Strings.Validations))]
       // [Required(ErrorMessageResourceName = "EmailRequired", ErrorMessageResourceType = typeof(RampedUp.Resources.Strings.Validations))]
        public string UserName { get; set; }

        //[Required(ErrorMessageResourceName = "UserPasswordRequired", ErrorMessageResourceType = typeof(RampedUp.Resources.Strings.Validations))]
        //[StringLength(100, ErrorMessageResourceName = "UserPasswordTooShort", ErrorMessageResourceType = typeof(RampedUp.Resources.Strings.Validations), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        // [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
     //   [Compare("Password", ErrorMessageResourceName = "UserPasswordConfirmationFailed", ErrorMessageResourceType = typeof(RampedUp.Resources.Strings.Validations))]
        public string ConfirmPassword { get; set; }

     //   [Required(ErrorMessageResourceName = "UserFirstNameRequired", ErrorMessageResourceType = typeof(RampedUp.Resources.Strings.Validations))]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

     //   [Required(ErrorMessageResourceName = "UserLastNameRequired", ErrorMessageResourceType = typeof(RampedUp.Resources.Strings.Validations))]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

 
    }
}
