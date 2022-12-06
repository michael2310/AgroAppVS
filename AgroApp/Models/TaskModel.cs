using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace AgroApp.Models
{
    [Table("Tasks")]
    public class TaskModel
    {
        [Key]
        public int TaskId { get; set; }
        [DisplayName("Temat")]
        public string Subject { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
        [DisplayName("Data utworzenia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDate { get; set; }
        [DisplayName("Przew. data zakończenia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ExpectedEndDate { get; set; }
        [DisplayName("Data zakończenia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dateTime { get; set; }
        [DisplayName("Otwarte")]
        public bool IsOpen { get; set; }
        [DisplayName("Zakończone")]
        public bool IsDone { get; set; }
        public string? UserId { get; set; }
        public UserModel? User { get; set; }

        public int? FarmId { get; set; }
        public FarmModel? Farm { get; set; }
    }
}
