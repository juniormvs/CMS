using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(UsuarioMetadado))]
    public partial class Usuario { }

    public class UsuarioMetadado
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int PessoaId { get; set; }
        public int PerfilId { get; set; }

        public virtual Perfil Perfil { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
