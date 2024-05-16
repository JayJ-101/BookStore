using System.ComponentModel.DataAnnotations;

namespace BookStore.Models  
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Please enter username.")]
        [StringLength(25)]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a password.")]
        [StringLength(25)]
        public string Password { get; set; }=string.Empty;

        public string ReturnUrl { get; set; } = string.Empty;

        public bool RememberMe { get; set; }
    }
}
