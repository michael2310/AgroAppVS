using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgroApp.Models
{
    [Table("Fields")]
    public class FieldModel
    {
        [Key]
        [DisplayName("Id")]
        public int FieldId { get; set; }
        [Required(ErrorMessage = "Numer działki jest wymagany")]
        [DisplayName("Numer działki")]
        public int Number { get; set; }
        [DisplayName("Nazwa")]
        [MaxLength(50)]
        public string Name { get; set; }
        [DisplayName("Powierzchnia")]
      
        public double Area { get; set; }

        [ForeignKey("Farm")]
        public int FarmId { get; set; }
        public FarmModel Farm { get; set; }
        public ICollection<EntryModel> Entry { get; set; }

        public static explicit operator List<object>(FieldModel v)
        {
            throw new NotImplementedException();
        }
    }
}
