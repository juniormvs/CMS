namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.Produto")]
    public partial class Produto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produto()
        {
            ImagemProduto = new HashSet<ImagemProduto>();
            ProdutoPorCategoria = new HashSet<ProdutoPorCategoria>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(145)]
        public string Nome { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Descricao { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string DadosTecnico { get; set; }

        [StringLength(45)]
        public string Imagem { get; set; }

        [StringLength(45)]
        public string Video { get; set; }

        public decimal? Preco { get; set; }

        [Required]
        [StringLength(145)]
        public string UrlAmigavel { get; set; }

        public bool PostarNoFacebook { get; set; }

        public bool Ativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImagemProduto> ImagemProduto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProdutoPorCategoria> ProdutoPorCategoria { get; set; }
    }
}
