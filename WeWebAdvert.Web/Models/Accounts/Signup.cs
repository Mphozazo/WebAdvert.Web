using System.ComponentModel.DataAnnotations;

namespace WeWebAdvert.Web.Models.Accounts
{
    public class Signup
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage ="Minimum of 6 in lenght.")]
        [Display(Name =("Password"))]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password and Confirmation does not match.")]
        [Display(Name = ("Confirm Password"))]
        public string ConfirmPassword { get; set; }
    }
}
