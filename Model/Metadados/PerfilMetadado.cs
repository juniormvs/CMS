using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(PerfilMetadado))]
    public partial class Perfil { }
    public class PerfilMetadado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
