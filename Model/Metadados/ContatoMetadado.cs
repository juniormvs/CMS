using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(ContatoMetadado))]
    public partial class Contato { }
    public class ContatoMetadado
    {
        public int Id { get; set; }
        public string Valor { get; set; }
        public int PessoaId { get; set; }
        public int TipoContatoId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual TipoContato TipoContato { get; set; }
    }
}
