using System.ComponentModel.DataAnnotations;

namespace WebApplication18.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
