using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(SlideMetadado))]
    public partial class Slide { }
    public class SlideMetadado
    {
        public int Id { get; set; }
        public string Imagem { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Url { get; set; }
    }
}
