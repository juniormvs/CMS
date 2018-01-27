namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.PublicacaoPorCategoria")]
    public partial class PublicacaoPorCategoria
    {
        public int Id { get; set; }

        public int CategoriaId { get; set; }

        public int PublicacaoId { get; set; }

        public virtual CategoriaPublicacao CategoriaPublicacao { get; set; }

        public virtual Publicacao Publicacao { get; set; }
    }
}
