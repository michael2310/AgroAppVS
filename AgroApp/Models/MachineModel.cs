using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroApp.Models
{
    [Table("Machines")]
    public class MachineModel
    {
        [Key]
        public int MachineId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public DateTime LastService { get; set; }

        [ForeignKey("Farm")]
        public int? FarmId { get; set; }
        public FarmModel? Farm { get; set; }

    }
}
