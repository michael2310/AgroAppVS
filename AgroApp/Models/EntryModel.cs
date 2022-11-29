namespace AgroApp.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    [Table("Entry")]
    public class EntryModel
    {
            [Key]
            public int EntryId { get; set; }
            [DisplayName("Typ pracy")]
            public String WorkType { get; set; }
            [DisplayName("Data wykonania")]
            public DateTime Date { get; set; }
            public String EntryInfo { get; set; }
            [DisplayName("Szczegóły")]
            public int FieldId { get; set; }
            public FieldModel Field { get; set; }
       
        
    }
