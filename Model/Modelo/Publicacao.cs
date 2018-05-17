namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("cms-mainsoftware.Publicacao")]
    public partial class Publicacao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Publicacao()
        {
            ImagemPublicacao = new HashSet<ImagemPublicacao>();
            PublicacaoPorCategoria = new HashSet<PublicacaoPorCategoria>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(140)]
        public string Titulo { get; set; }

        [StringLength(200)]
        public string Resumo { get; set; }

        [AllowHtml]
        [Column(TypeName = "text")]
        [Required]
        [StringLength(65535)]
        public string Texto { get; set; }

        [StringLength(145)]
        public string Imagem { get; set; }

        public DateTime DataPublicacao { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public bool ExibirComoPopup { get; set; }

        public bool ExibirImagem { get; set; }

        [Required]
        [StringLength(145)]
        public string UrlAmigavel { get; set; }

        public bool PostarNoFacebook { get; set; }

        public int StatusId { get; set; }

        [StringLength(45)]
        public string Autor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImagemPublicacao> ImagemPublicacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PublicacaoPorCategoria> PublicacaoPorCategoria { get; set; }

        public virtual Status Status { get; set; }
    }
}
