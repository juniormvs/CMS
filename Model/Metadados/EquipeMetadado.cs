using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(EquipeMetadado))]
    public partial class Equipe { }
    public class EquipeMetadado
    {
        public int Id { get; set; }
        public string Foto { get; set; }
        public string Cargo { get; set; }

        [Display(Name = "Creci")]
        public string DocumentoProfissional { get; set; }
        public int PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
