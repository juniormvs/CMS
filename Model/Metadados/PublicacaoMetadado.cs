using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Model
{
    [MetadataType(typeof(PublicacaoMetadado))]
    public partial class Publicacao { }
    public class PublicacaoMetadado
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor, informe um título para a publicação")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        [AllowHtml]
        [Display(Name = "Texto da publicação")]
        public string Texto { get; set; }
        public string Imagem { get; set; }
        [Display(Name = "Data de Publicação", Description = "Selecione uma data futura para agendar uma publicação")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public System.DateTime DataPublicacao { get; set; }
        [Display(Name = "Data de atualização")]
        public Nullable<System.DateTime> DataAtualizacao { get; set; }
        [Display(Name = "Exibir como popup", Description = "Exibe a publicação como destaque no site")]
        public sbyte ExibirComoPopup { get; set; }
        [Display(Name = "Exibir Imagem", Description = "Exibe a imagem principal como destaque na publicação")]
        public sbyte ExibirImagem { get; set; }
        public string UrlAmigavel { get; set; }
        [Display(Name = "Publicar no Facebook", Description = "Posta no facebook a publicação automaticamente")]
        public bool PostarNoFacebook { get; set; }
        [Display(Name = "Status")]
        public int StatusId { get; set; }
        [Display(Name = "Autor")]
        public string Autor { get; set; }

        public virtual ICollection<ImagemPublicacao> ImagemPublicacao { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<PublicacaoPorCategoria> PublicacaoPorCategoria { get; set; }
    }
}
