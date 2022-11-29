using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgroApp.Models
{
    public class LoginModel
    {
        [Required]
        [DisplayName("Login")]
        public string Login { get; set; }

        [Required]
        [DisplayName("Hasło")]
        public string Password { get; set; }
    }
}
