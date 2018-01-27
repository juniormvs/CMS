namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.Download")]
    public partial class Download
    {
        public int Id { get; set; }

        [Required]
        [StringLength(145)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(45)]
        public string MimeType { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(145)]
        public string Arquivo { get; set; }

        public bool Ativo { get; set; }
    }
}
