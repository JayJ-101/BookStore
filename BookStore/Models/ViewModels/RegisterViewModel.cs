using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter username")]
        [StringLength(25)]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage="Please enter a password." )]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password{get;set;} = string.Empty;

        [Required(ErrorMessage = "Please confirm password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }   
}
