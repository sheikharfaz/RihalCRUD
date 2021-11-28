using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCRUD.Models
{
    public class BaseEntities
    {
        [Column("create_date")]
        public DateTime CreatedDate { get; set; }

        [Column("modified_date")]
        public DateTime ModifiedDate { get; set; }
    }
}
