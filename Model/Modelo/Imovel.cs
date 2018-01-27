namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.Imovel")]
    public partial class Imovel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Imovel()
        {
            DetalhePorImovel = new HashSet<DetalhePorImovel>();
            ImagemImovel = new HashSet<ImagemImovel>();
            ImoveInformacao = new HashSet<ImoveInformacao>();
        }

        public int Id { get; set; }

        [StringLength(45)]
        public string Codigo { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Descricao { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string CentralNegocio { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string PontosFortes { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Observacao { get; set; }

        [StringLength(200)]
        public string Imagem { get; set; }

        [StringLength(200)]
        public string UrlAmigavel { get; set; }

        public DateTime? DataCadastro { get; set; }

        public DateTime? DataExclusao { get; set; }

        [StringLength(245)]
        public string UsuarioExclusao { get; set; }

        public bool Destaque { get; set; }

        public decimal? Valor { get; set; }

        public decimal? Iptu { get; set; }

        public decimal? Condominio { get; set; }

        public decimal? Taxa { get; set; }

        [StringLength(256)]
        public string ObservacaoValor { get; set; }

        public int? Dormitorio { get; set; }

        public int? Suite { get; set; }

        public int? Banheiro { get; set; }

        public int? Garagem { get; set; }

        public int? Acomodacoes { get; set; }

        public bool? Mobiliado { get; set; }

        public bool? EmCondominio { get; set; }

        public int? AnoConstrucao { get; set; }

        [StringLength(45)]
        public string Pavimento { get; set; }

        [StringLength(45)]
        public string Video { get; set; }

        [StringLength(10)]
        public string Cep { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string EnderecoGoogle { get; set; }

        [StringLength(256)]
        public string Logradouro { get; set; }

        [StringLength(45)]
        public string Numero { get; set; }

        [StringLength(145)]
        public string Complemento { get; set; }

        [StringLength(45)]
        public string Zona { get; set; }

        [StringLength(45)]
        public string Regiao { get; set; }

        [StringLength(256)]
        public string PontoReferencia { get; set; }

        [StringLength(45)]
        public string Latitude { get; set; }

        [StringLength(45)]
        public string Longitude { get; set; }

        public bool? GerarMapa { get; set; }

        public bool? IncluirNoMapa { get; set; }

        public double? AreaTotal { get; set; }

        [StringLength(45)]
        public string UnMedidaTotal { get; set; }

        public double? AreaPrivativa { get; set; }

        [StringLength(45)]
        public string UnMedidaPrivativa { get; set; }

        public double? AreaConstruida { get; set; }

        [StringLength(45)]
        public string UnMedidaConstruida { get; set; }

        public double? AreaTerreno { get; set; }

        [StringLength(45)]
        public string UnMedidaTerreno { get; set; }

        public double? TerrenoFrente { get; set; }

        [StringLength(45)]
        public string UnMedidaTerrenoFrente { get; set; }

        public double? TerrenoFundo { get; set; }

        [StringLength(45)]
        public string UnMedidaTerrenoFundo { get; set; }

        public double? TerrenoDireita { get; set; }

        [StringLength(45)]
        public string UnMedidaTerrenoDireita { get; set; }

        public double? TerrenoEsquerrda { get; set; }

        [StringLength(45)]
        public string UnMedidaTerrenoEsquerda { get; set; }

        public int TipoContratoId { get; set; }

        public int TipoImovelId { get; set; }

        public int StatusId { get; set; }

        public int BairroId { get; set; }

        public int CidadeId { get; set; }

        public int? CorretorPessoaId { get; set; }

        public int? ProprietarioPessoaId { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        [StringLength(145)]
        public string NomeCondominio { get; set; }

        public virtual Bairro Bairro { get; set; }

        public virtual Cidade Cidade { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalhePorImovel> DetalhePorImovel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImagemImovel> ImagemImovel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImoveInformacao> ImoveInformacao { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public virtual Pessoa Pessoa1 { get; set; }

        public virtual TipoContrato TipoContrato { get; set; }

        public virtual TipoImovel TipoImovel { get; set; }

        public virtual Status Status { get; set; }
    }
}
