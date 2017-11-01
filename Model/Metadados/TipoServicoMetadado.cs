using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(TipoServicoMetadado))]
    public partial class TipoServico { }
    public class TipoServicoMetadado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
