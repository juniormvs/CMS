using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(PerfilPessoaMetadado))]
    public partial class PerfilPessoa { }
    public class PerfilPessoaMetadado
    {
        public int Id { get; set; }
        [Display(Name ="Perfil")]
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}
