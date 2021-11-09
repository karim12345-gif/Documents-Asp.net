namespace DocumentsProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Table")]
    public partial class Table
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string Subject { get; set; }

        [StringLength(10)]
        public string DocumentType { get; set; }

        [StringLength(50)]
        public string DocumentDate { get; set; }

        public int? SerialNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Year { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        [StringLength(10)]
        public string CreatedBy { get; set; }

        public string File { get; set; }
    }
}
