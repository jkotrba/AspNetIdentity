using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetIdentity.WebApi.Models
{
    public class ChangePasswordBindingModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Current password")]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="New password")]
        [StringLength(100, ErrorMessage= "The {0} must be at least {2} characters long.", MinimumLength=6)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Confirm new password")]
        [Compare("NewPassword", ErrorMessage="The new password and confirm password do not match.")]
        public string PasswordConfirm { get; set; }
    }
}