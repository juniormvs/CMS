namespace Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    [Table("cms-mainsoftware.Servico")]
    public partial class Servico
    {
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string Nome { get; set; }

        [StringLength(120)]
        public string Resumo { get; set; }

        [AllowHtml]
        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Descricao { get; set; }

        [StringLength(45)]
        public string Icone { get; set; }

        [StringLength(145)]
        public string Imagem { get; set; }

        [StringLength(145)]
        public string UrlAmigavel { get; set; }

        public bool Ativo { get; set; }

        public int TipoId { get; set; }

        public virtual TipoServico TipoServico { get; set; }
    }
}
