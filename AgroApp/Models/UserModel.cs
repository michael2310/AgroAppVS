
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroApp.Models
{

    public class UserModel : IdentityUser
    {
        public string Position { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        [ForeignKey("Farm")]
        public int? FarmId { get; set; }
        public FarmModel? Farm { get; set; }

        public FarmModel? OwnershipFarm { get; set; }
        //public ICollection<FarmModel>? Farms { get; set; }

    }
}
