using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(RedeSocialMetadado))]
    public partial class RedeSocial { }
    public class RedeSocialMetadado
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int RedeId { get; set; }
        public int PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual Rede Rede { get; set; }
    }
}
