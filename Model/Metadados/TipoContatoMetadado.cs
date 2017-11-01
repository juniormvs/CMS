using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(TipoContatoMetadado))]
    public partial class TipoContato { }
    public class TipoContatoMetadado
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Icone { get; set; }
    }
}
