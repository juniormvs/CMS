namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.ImagemPublicacao")]
    public partial class ImagemPublicacao
    {
        public int Id { get; set; }

        [Required]
        [StringLength(145)]
        public string Imagem { get; set; }

        [StringLength(145)]
        public string Legenda { get; set; }

        public int Ordem { get; set; }

        public int PublicacaoId { get; set; }

        public virtual Publicacao Publicacao { get; set; }
    }
}
