using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroApp.Models
{
    [Table("Tasks")]
    public class TaskModel
    {
        [Key]
        public int TaskId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public DateTime dateTime { get; set; }
        public bool IsOpen { get; set; }
        public bool IsDone { get; set; }
        public string? UserId { get; set; }
        public UserModel? User { get; set; }

        public int? FarmId { get; set; }
        public FarmModel? Farm { get; set; }
    }
}
