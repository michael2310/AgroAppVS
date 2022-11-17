using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AgroApp.Models
{
    [Table("Farms")]
    
    public class FarmModel
    {
        [Key]
        public int FarmId { get; set; }
        public String FarmName { get; set; }
        public Boolean FarmStatus { get; set; }
        public ICollection<UserModel>? users { get; set; }
        public ICollection<TaskModel>? tasks { get; set; }

        public ICollection<FieldModel>? fields { get; set; }

        public ICollection<MachineModel>? Machines { get; set; }

        [ForeignKey("FarmOwner")]
       
        public string? FarmOwnerId { get; set; }
        
        public UserModel? FarmOwner { get; set; }

    }
}
