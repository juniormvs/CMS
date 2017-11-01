using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(LinkMetadado))]
    public partial class Link { }
    public class LinkMetadado
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor, informe um título")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Por favor, informe um endereço")]
        [Display(Name = "URL / Site / Link")]
        public string Url { get; set; }
        public string Target { get; set; }
        public int StatusId { get; set; }

        public virtual Status Status { get; set; }
    }
}
