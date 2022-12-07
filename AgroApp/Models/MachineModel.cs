using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroApp.Models
{
    [Table("Machines")]
    public class MachineModel
    {
        [Key]
        public int MachineId { get; set; }
        [DisplayName("Marka")]
        public string Brand { get; set; }
        [DisplayName("Model")]
        public string Model { get; set; }
        [DisplayName("Data produkcji")]
        public int ProductionYear { get; set; }
        [DisplayName("Ostatni serwis")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LastService { get; set; }

        [ForeignKey("Farm")]
        public int? FarmId { get; set; }
        public FarmModel? Farm { get; set; }

        public ICollection<MachineServiceModel> Services { get; set; }

    }
}
