using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(ClienteParceiroMetadado))]
    public partial class ClienteParceiro { }
    public class ClienteParceiroMetadado
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Tipo { get; set; }
        public int PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
