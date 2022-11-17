namespace AgroApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    [Table("Entry")]
    public class EntryModel
    {
            [Key]
            public int EntryId { get; set; }
            public String WorkType { get; set; }
            public DateTime Date { get; set; }
            public String EntryInfo { get; set; }
            public int FieldId { get; set; }
            public FieldModel Field { get; set; }
       
        
    }
