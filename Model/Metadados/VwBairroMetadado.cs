using System.ComponentModel.DataAnnotations;

namespace Model.Metadados
{
    [MetadataType(typeof(VwBairroMetadado))]
    public partial class VwBairro { }

    public class VwBairroMetadado
    {
        public string Id { get; set; }
        [Display(Name = "Bairro")]
        public string NomeBairro { get; set; }
        public string BairroUrl { get; set; }
    }
}
