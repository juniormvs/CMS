namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.Depoimento")]
    public partial class Depoimento
    {
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string Autor { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [StringLength(65535)]
        public string Texto { get; set; }

        [StringLength(100)]
        public string Imagem { get; set; }

        public bool Ativo { get; set; }
    }
}
