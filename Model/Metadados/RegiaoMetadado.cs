using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(RegiaoMetadado))]
    public partial class Regiao { }
    public class RegiaoMetadado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
