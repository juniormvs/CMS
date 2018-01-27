namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.Slide")]
    public partial class Slide
    {
        public int Id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [StringLength(65535)]
        public string Imagem { get; set; }

        [StringLength(60)]
        public string Titulo { get; set; }

        [StringLength(145)]
        public string Subtitulo { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Url { get; set; }

        public bool Ativo { get; set; }
    }
}
