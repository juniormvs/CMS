namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.Estado")]
    public partial class Estado
    {
        public int Id { get; set; }

        public int CodigoUf { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(2)]
        public string Uf { get; set; }

        public int Regiao { get; set; }
    }
}
