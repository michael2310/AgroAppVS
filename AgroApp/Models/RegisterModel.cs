﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AgroApp.Models
{
    public class RegisterModel
    {
        [Required]
        [DisplayName("Imię")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Nazwisko")]
        public string Surname { get; set; }
        [Required]
        [DisplayName("Nazwa użytkownika")]
        public string UserName { get; set; }
        [EmailAddress]
        [Required]
        [StringLength(100, ErrorMessage = "Adres istnieje w bazie danych")]
        [DisplayName("Adres e-mail")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Hasło musi zawierać przynajmniej {2} znaków, małe i duże litery oraz znak specjalny.", MinimumLength = 8)]
        [DisplayName("Hasło")]
        public string Password { get; set; }
        [DisplayName("Stanowisko")]
        public string Position { get; set; }

        //powiazanie z gospodarstwem
        [DisplayName("Gospodarstwo")]
        public int? FarmId { get; set; }

        [Required]
        [DisplayName("Typ konta")]
        public string RoleName { get; set; }
    }
}
