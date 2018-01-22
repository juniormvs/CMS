using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Model
{
    [MetadataType(typeof(ImovelMetadado))]
    public partial class Imovel { }

    public class ImovelMetadado
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Display(Name = "Descrição", Description = "Descrição do imóvel")]
        [AllowHtml]
        public string Descricao { get; set; }

        [Display(Name = "Central de negócios")]
        [AllowHtml]
        public string CentralNegocio { get; set; }

        [Display(Name = "Pontos Fortes")]
        [AllowHtml]
        public string PontosFortes { get; set; }

        [Display(Name = "Observação")]
        [AllowHtml]
        public string Observacao { get; set; }

        [Display(Name = "Imagem Principal", Description = "Imagem destaque do imóvel")]
        public string Imagem { get; set; }

        public string UrlAmigavel { get; set; }

        [Display(Name = "Data de Cadastro")]
        public Nullable<System.DateTime> DataCadastro { get; set; }

        [Display(Name = "Data de Exclusão")]
        public Nullable<System.DateTime> DataExclusao { get; set; }

        [Display(Name = "Usuário Exclusão")]
        public string UsuarioExclusao { get; set; }

        [Display(Name = "Exibir como destaque")]
        public bool Destaque { get; set; }

        [Display(Name = "Valor do Imóvel")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> Valor { get; set; }

        [Display(Name = "IPTU")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> Iptu { get; set; }

        [Display(Name = "Valor do Condomínio")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> Condominio { get; set; }

        [Display(Name = "Taxas")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> Taxa { get; set; }

        [Display(Name = "Observação do Valor")]
        [DataType(DataType.Currency)]
        public string ObservacaoValor { get; set; }

        [Display(Name = "Dormitórios")]
        public Nullable<int> Dormitorio { get; set; }

        [Display(Name = "Suítes")]
        public Nullable<int> Suite { get; set; }

        [Display(Name = "Banheiros")]
        public Nullable<int> Banheiro { get; set; }

        [Display(Name = "Garagens")]
        public Nullable<int> Garagem { get; set; }

        [Display(Name = "Acomodações")]
        public Nullable<int> Acomodacoes { get; set; }

        [Display(Name = "Mobiliado")]
        public Nullable<bool> Mobiliado { get; set; }

        [Display(Name = "Em Condomínio")]
        public Nullable<bool> EmCondominio { get; set; }

        [Display(Name = "Ano Construção")]
        public Nullable<int> AnoConstrucao { get; set; }

        [Display(Name = "Pavimento")]
        public string Pavimento { get; set; }

        [Display(Name = "Vídeo")]
        public string Video { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Display(Name = "Endereço Completo")]
        public string EnderecoGoogle { get; set; }

        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Display(Name = "Zona")]
        public string Zona { get; set; }

        [Display(Name = "Região")]
        public string Regiao { get; set; }

        [Display(Name = "Ponto de Referência")]
        public string PontoReferencia { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        [Display(Name = "Gerar Mapa")]
        public Nullable<bool> GerarMapa { get; set; }

        [Display(Name = "Incluir no Mapa")]
        public Nullable<bool> IncluirNoMapa { get; set; }

        [Display(Name = "Área Total")]
        public Nullable<double> AreaTotal { get; set; }
        public string UnMedidaTotal { get; set; }

        [Display(Name = "Área Privativa")]
        public Nullable<double> AreaPrivativa { get; set; }
        public string UnMedidaPrivativa { get; set; }

        [Display(Name = "Área Construída")]
        public Nullable<double> AreaConstruida { get; set; }
        public string UnMedidaConstruida { get; set; }

        [Display(Name = "Área Terreno")]
        public Nullable<double> AreaTerreno { get; set; }
        public string UnMedidaTerreno { get; set; }

        [Display(Name = "Terreno Frente")]
        public Nullable<double> TerrenoFrente { get; set; }
        public string UnMedidaTerrenoFrente { get; set; }

        [Display(Name = "Terreno Fundo")]
        public Nullable<double> TerrenoFundo { get; set; }
        public string UnMedidaTerrenoFundo { get; set; }

        [Display(Name = "Terreno Direita")]
        public Nullable<double> TerrenoDireita { get; set; }
        public string UnMedidaTerrenoDireita { get; set; }

        [Display(Name = "Terreno Esquerda")]
        public Nullable<double> TerrenoEsquerrda { get; set; }
        public string UnMedidaTerrenoEsquerda { get; set; }

        [Display(Name = "Nome do Condomínio")]
        public string NomeCondominio { get; set; }

        [Display(Name = "Finalidade")]
        public int TipoContratoId { get; set; }

        [Display(Name = "Tipo do Imóvel")]
        public int TipoImovelId { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }

        [Display(Name = "Bairro")]
        public int BairroId { get; set; }

        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }

        [Display(Name = "Bairro")]
        public virtual Bairro Bairro { get; set; }
        public virtual ICollection<DetalhePorImovel> DetalhePorImovel { get; set; }
        public virtual ICollection<ImagemImovel> ImagemImovel { get; set; }
        public virtual ICollection<ImoveInformacao> ImoveInformacao { get; set; }
        [Display(Name = "Finalidade")]
        public virtual TipoContrato TipoContrato { get; set; }
        [Display(Name = "Tipo do Imóvel")]
        public virtual TipoImovel TipoImovel { get; set; }
        [Display(Name = "Status")]
        public virtual Status Status { get; set; }
        [Display(Name = "Cidade")]
        public virtual Cidade Cidade { get; set; }
    }
}
