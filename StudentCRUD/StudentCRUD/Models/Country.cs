using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCRUD.Models
{
    [Table("countries")]
    public class Country : BaseEntities
    {
        [Key]
        public int Id { get; set; }

        [Column("name", TypeName = "varchar(25)")]
        public string Name { get; set; }

        [ForeignKey("CountryId")]
        public ICollection<Student> Students { get; set; }
    }
}
