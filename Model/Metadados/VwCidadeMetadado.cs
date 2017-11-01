using System.ComponentModel.DataAnnotations;

namespace Model.Metadados
{
    [MetadataType(typeof(VwCidadeMetadado))]
    public partial class VwCidade { }

    public class VwCidadeMetadado
    {
        public string Id { get; set; }
        [Display(Name = "Cidade")]
        public string NomeCidade { get; set; }
        public string CidadeUrl { get; set; }
    }
}
