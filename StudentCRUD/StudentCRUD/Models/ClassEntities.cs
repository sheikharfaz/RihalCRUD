using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCRUD.Models
{
    [Table("classes")]
    public class ClassEntities: BaseEntities
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("class_name")]
        public string? ClassName { get; set; }

        [ForeignKey("ClassId")]
        public ICollection<Student> Students { get; set; }

    }
}
