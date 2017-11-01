using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(StatusMetadado))]
    public partial class Status { }
    public class StatusMetadado
    {
        public int Id { get; set; }
        [Display(Name = "Status")]
        public string Nome { get; set; }
    }
}
