namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.Video")]
    public partial class Video
    {
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string YoutubeId { get; set; }

        [Required]
        [StringLength(145)]
        public string Titulo { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(145)]
        public string UrlAmigavel { get; set; }

        public bool Ativo { get; set; }
    }
}
