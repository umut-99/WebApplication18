using System.ComponentModel.DataAnnotations;

namespace WebApplication18.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PassWord { get; set; }
        
        public string Role { get; set; } = "user";
    }
}
