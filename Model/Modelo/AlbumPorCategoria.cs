namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.AlbumPorCategoria")]
    public partial class AlbumPorCategoria
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int AlbumId { get; set; }

        public int CategoriaAlbumId { get; set; }

        public virtual Album Album { get; set; }

        public virtual CategoriaAlbum CategoriaAlbum { get; set; }
    }
}
