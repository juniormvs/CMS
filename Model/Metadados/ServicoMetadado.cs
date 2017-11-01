using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Model
{
    [MetadataType(typeof(ServicoMetadado))]
    public partial class Servico { }

    public class ServicoMetadado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [MaxLength(120, ErrorMessage = "O resumo deve ter no máximo 120 caracteres.")]
        public string Resumo { get; set; }
        [AllowHtml]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public string Icone { get; set; }
        public string Imagem { get; set; }
        public string UrlAmigavel { get; set; }
        public int TipoId { get; set; }
        public int StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual TipoServico TipoServico { get; set; }
    }
}
