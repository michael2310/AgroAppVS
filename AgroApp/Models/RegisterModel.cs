using System.ComponentModel.DataAnnotations;

namespace AgroApp.Models
{
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string Position { get; set; }

        //powiazanie z gospodarstwem
        
        public int? FarmId { get; set; }
    }
}
