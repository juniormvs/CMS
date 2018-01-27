namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.ImagemAlbum")]
    public partial class ImagemAlbum
    {
        public int Id { get; set; }

        [Required]
        [StringLength(145)]
        public string Imagem { get; set; }

        [StringLength(145)]
        public string Legenda { get; set; }

        public int Ordem { get; set; }

        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}
