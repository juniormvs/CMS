using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(ImagemPublicacaoMetadado))]
    public partial class ImagemPublicacao { }
    public class ImagemPublicacaoMetadado
    {
        public int Id { get; set; }
        public string Imagem { get; set; }
        public string Legenda { get; set; }
        public int Ordem { get; set; }
        public int PublicacaoId { get; set; }

        public virtual Publicacao Publicacao { get; set; }
    }
}
