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
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Por favor, informe um título para o anúncio do imóvel")]
        [Display(Name = "Título", Description = "Título do anúncio do imóvel")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição", Description = "Descrição do imóvel")]
        [AllowHtml]
        public string Descricao { get; set; }

        [Display(Name = "Central de negócios")]
        [AllowHtml]
        public string CentralNegocio { get; set; }

        [Display(Name = "Imagem Principal", Description = "Imagem destaque do imóvel")]
        public string Imagem { get; set; }

        [Display(Name = "Valor")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> Valor { get; set; }

        [Display(Name = "Valor do condominio")]
        public Nullable<decimal> ValorCondominio { get; set; }

        [Display(Name = "Área Total (m²)")]
        public Nullable<double> AreaTotal { get; set; }

        [Display(Name = "Área Construída (m²)")]
        public Nullable<double> AreaConstruida { get; set; }

        [Display(Name = "Quantidade de dormitórios", ShortName = "Qtd. Dormitório")]
        public Nullable<int> Dormitorio { get; set; }

        [Display(Name = "Quantidade de suítes", ShortName = "Qtd. Suíte")]
        public Nullable<int> Suite { get; set; }

        [Display(Name = "Quantidade de banheiros", ShortName = "Qtd. Banheiro")]
        public Nullable<int> Banheiro { get; set; }

        [Display(Name = "Quantidade de garagens", ShortName = "Qtd. Garagem")]
        public Nullable<int> Garagem { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }
        [Display(Name = "Estado")]
        public string Uf { get; set; }
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }
        [Display(Name = "CEP")]
        public string Cep { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        [Display(Name = "Tipo de imóvel")]
        public int TipoImovelId { get; set; }

        [Display(Name = "Tipo de contrato")]
        public int TipoContratoId { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }

        [Display(Name = "Data de Exclusão")]
        public Nullable<System.DateTime> DataExclusao { get; set; }

        [Display(Name = "Usuário de Exclusão")]
        public string UsuarioExclusao { get; set; }

        public string UrlAmigavel { get; set; }

        public Nullable<System.DateTime> DataCadastro { get; set; }


        public virtual ICollection<ImagemImovel> ImagemImovel { get; set; }
        public virtual TipoContrato TipoContrato { get; set; }
        public virtual TipoImovel TipoImovel { get; set; }
        public virtual Status Status { get; set; }
    }
}
