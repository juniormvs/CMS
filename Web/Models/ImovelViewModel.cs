using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Web.Models
{
    public class ImovelViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        [AllowHtml]
        public string Descricao { get; set; }
        [AllowHtml]
        [Display(Name = "Central de Negócio")]
        public string CentralNegocio { get; set; }
        public string PontosFortes { get; set; }
        public string Observacao { get; set; }
        public string Imagem { get; set; }
        public string UrlAmigavel { get; set; }
        public string DataCadastro { get; set; }
        public string DataExclusao { get; set; }
        public string UsuarioExclusao { get; set; }
        public bool Destaque { get; set; }
        public string Valor { get; set; }
        public string Iptu { get; set; }
        public string Condominio { get; set; }
        public string Taxa { get; set; }
        public string ObservacaoValor { get; set; }
        public Nullable<int> Dormitorio { get; set; }
        public Nullable<int> Suite { get; set; }
        public Nullable<int> Banheiro { get; set; }
        public Nullable<int> Garagem { get; set; }
        public Nullable<int> Acomodacoes { get; set; }
        public Nullable<bool> Mobiliado { get; set; }
        public Nullable<bool> EmCondominio { get; set; }
        public Nullable<int> AnoConstrucao { get; set; }
        public string Pavimento { get; set; }
        public string Video { get; set; }
        public string Cep { get; set; }
        public string EnderecoGoogle { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Zona { get; set; }
        public string Regiao { get; set; }
        public string PontoReferencia { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Nullable<bool> GerarMapa { get; set; }
        public Nullable<bool> IncluirNoMapa { get; set; }
        public string AreaTotal { get; set; }
        public string UnMedidaTotal { get; set; }
        public string AreaPrivativa { get; set; }
        public string UnMedidaPrivativa { get; set; }
        public string AreaConstruida { get; set; }
        public string UnMedidaConstruida { get; set; }
        public string AreaTerreno { get; set; }
        public string UnMedidaTerreno { get; set; }
        public string TerrenoFrente { get; set; }
        public string UnMedidaTerrenoFrente { get; set; }
        public string TerrenoFundo { get; set; }
        public string UnMedidaTerrenoFundo { get; set; }
        public string TerrenoDireita { get; set; }
        public string UnMedidaTerrenoDireita { get; set; }
        public string TerrenoEsquerrda { get; set; }
        public string UnMedidaTerrenoEsquerda { get; set; }
        public int TipoContratoId { get; set; }
        public int TipoImovelId { get; set; }
        public int StatusId { get; set; }
        public int BairroId { get; set; }
        public int CidadeId { get; set; }
        public Nullable<int> CorretorPessoaId { get; set; }
        public Nullable<int> ProprietarioPessoaId { get; set; }
        public string UserId { get; set; }

        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        
    }

    public class ImovelApiViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public Nullable<double> AreaTotal { get; set; }
        public Nullable<double> AreaConstruida { get; set; }
        public Nullable<int> Dormitorio { get; set; }
        public Nullable<int> Suite { get; set; }
        public Nullable<int> Banheiro { get; set; }
        public Nullable<int> Garagem { get; set; }
        public string Endereco { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string TipoImovel { get; set; }
        public string TipoContrato { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string UrlAmigavel { get; set; }
        
    }
}