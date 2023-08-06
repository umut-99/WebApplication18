using System.ComponentModel.DataAnnotations;

namespace WebApplication18.Entities
{
    public class SahiplendirilmisHayvan
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string İsim { get; set; }
        [Required]
        public string Tür { get; set; }
        [Required]
        public string Cins { get; set; }
    }
}
