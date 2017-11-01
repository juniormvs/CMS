using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(ImagemImovelMetadado))]
    public partial class ImagemImovel { }
    public class ImagemImovelMetadado
    {
        public int Id { get; set; }
        public string Imagem { get; set; }
        public Nullable<int> Ordem { get; set; }
        public int ImovelId { get; set; }

        public virtual Imovel Imovel { get; set; }
    }
}
