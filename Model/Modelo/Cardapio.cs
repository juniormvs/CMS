namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.Cardapio")]
    public partial class Cardapio
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(145)]
        public string Titulo { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Ingredientes { get; set; }

        public decimal? Preco { get; set; }

        [StringLength(145)]
        public string Imagem { get; set; }

        public bool Ativo { get; set; }

        public int CardapioCategoriaId { get; set; }

        public virtual CardapioCategoria CardapioCategoria { get; set; }
    }
}
