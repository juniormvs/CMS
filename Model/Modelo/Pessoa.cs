namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("cms-mainsoftware.Pessoa")]
    public partial class Pessoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pessoa()
        {
            Imovel = new HashSet<Imovel>();
            Imovel1 = new HashSet<Imovel>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(145)]
        public string Nome { get; set; }

        [StringLength(45)]
        public string Tipo { get; set; }

        [StringLength(45)]
        public string CpfCnpj { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataCadastro { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataNascimento { get; set; }

        [StringLength(145)]
        public string Imagem { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        [AllowHtml]
        public string Bio { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Observacao { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Interesse { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Oferecido { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Informacao { get; set; }

        [StringLength(45)]
        public string DocumentoProfissional { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }

        [StringLength(20)]
        public string Celular { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Whatsapp { get; set; }

        [StringLength(20)]
        public string Skype { get; set; }

        public bool Ativo { get; set; }

        [StringLength(256)]
        public string ObservacaoTipoCadastro { get; set; }

        [StringLength(256)]
        public string Url { get; set; }

        public int PerfilPessoaId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imovel> Imovel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imovel> Imovel1 { get; set; }

        public virtual PerfilPessoa PerfilPessoa { get; set; }
    }
}
