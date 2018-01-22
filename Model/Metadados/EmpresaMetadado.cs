using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Model
{
    [MetadataType(typeof(EmpresaMetadado))]
    public partial class Empresa { }
    public class EmpresaMetadado
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [AllowHtml]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public string Resumo { get; set; }

        [AllowHtml]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Whatsapp { get; set; }
        public string Email { get; set; }
        public string Imagem { get; set; }
        public string Logo { get; set; }
        public string TemaPainel { get; set; }
        public string Latitute { get; set; }
        public string Longitude { get; set; }
    }
}
