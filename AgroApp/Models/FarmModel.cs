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
        [DisplayName("Nazwa farmy")]
        public String FarmName { get; set; }
        [DisplayName("Status farmy")]
        public Boolean FarmStatus { get; set; }
        public ICollection<UserModel>? users { get; set; }
        public ICollection<TaskModel>? tasks { get; set; }

        public ICollection<FieldModel>? fields { get; set; }

        public ICollection<MachineModel>? Machines { get; set; }

        [ForeignKey("FarmOwner")]
        [DisplayName("Właściciel")]
        public string? FarmOwnerId { get; set; }
        [DisplayName("Właściciel")]
        public string? FarmOwnerName { get; set; }
        public UserModel? FarmOwner { get; set; }

    }
}
