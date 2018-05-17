namespace Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    [Table("cms-mainsoftware.ImoveInformacao")]
    public partial class ImoveInformacao
    {
        public int Id { get; set; }

        public DateTime? DataCadastro { get; set; }

        [StringLength(45)]
        public string Disponibilidade { get; set; }

        public bool Exclusividade { get; set; }

        public bool Autorizacao { get; set; }

        public bool Averbada { get; set; }

        public bool Escriturada { get; set; }

        public bool Financiamento { get; set; }

        public bool ComPlaca { get; set; }

        [StringLength(256)]
        public string LocalChave { get; set; }

        [AllowHtml]
        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Informacao { get; set; }

        public int ImovelId { get; set; }

        public virtual Imovel Imovel { get; set; }
    }
}
