using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(CategoriaPublicacaoMetadado))]
    public partial class CategoriaPublicacao { }
    public class CategoriaPublicacaoMetadado
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor, informe um nome")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlAmigavel { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<PublicacaoPorCategoria> PublicacaoPorCategoria { get; set; }
    }
}
