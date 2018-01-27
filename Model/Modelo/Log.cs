namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.Log")]
    public partial class Log
    {
        public int Id { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime? Datetime { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Thread { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Level { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Logger { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Message { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Exception { get; set; }
    }
}
