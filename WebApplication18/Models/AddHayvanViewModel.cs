using System.ComponentModel.DataAnnotations;

namespace WebApplication18.Models
{
    public class AddHayvanViewModel
    {
        [Required]
        public string İsim { get; set; }
        [Required]
        public string Tür { get; set; }
        [Required]
        public string Cins { get; set; }
    }
}
