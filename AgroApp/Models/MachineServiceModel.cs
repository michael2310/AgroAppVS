using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroApp.Models
{
    [Table("Service")]
    public class MachineServiceModel
    {
        [Key]
        public int ServiceId { get; set; }
        [DisplayName("Data serwisu")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ServiceDate { get; set; }
        [DisplayName("Szczegóły")]
        public String ServiceInfo { get; set; }
        public int MachineId { get; set; }
        public MachineModel Machine { get; set; }
    }
}
