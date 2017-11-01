using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(MensagemMetadado))]
    public partial class Mensagem { }
    public class MensagemMetadado
    {
        public int Id { get; set; }
        public string Remetente { get; set; }
        public string Email { get; set; }
        public string Assunto { get; set; }
        public string Telefone { get; set; }
        public string Conteudo { get; set; }
        public System.DateTime Data { get; set; }
        public bool Lida { get; set; }
    }
}
