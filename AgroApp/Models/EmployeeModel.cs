using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroApp.Models
{
    [Table("Employees")]
    public class EmployeeModel
    {
       [Key]
        public int EmployeeId { get; set; }
        public String EmployeeName { get; set; }
        public String EmployeeSurname { get; set; }
        public int EmployeeAge { get; set; }
        public String EmployeePosition { get; set; }
        public String EmployeeStatus { get; set; }

    }
}
