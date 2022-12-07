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
        [DisplayName("Imię")]
        public String EmployeeName { get; set; }
        [DisplayName("Nazwisko")]
        public String EmployeeSurname { get; set; }
        [DisplayName("Wiek")]
        public int EmployeeAge { get; set; }
        [DisplayName("Stanowisko")]
        public String EmployeePosition { get; set; }
        [DisplayName("Status")]
        public String EmployeeStatus { get; set; }

    }
}
