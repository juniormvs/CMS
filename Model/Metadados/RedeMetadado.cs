using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(RedeMetadado))]
    public partial class Rede { }
    public class RedeMetadado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UrlBase { get; set; }
        public string Icone { get; set; }
    }
}
