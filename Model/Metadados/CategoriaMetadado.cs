using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(CategoriaMetadado))]
    public partial class Categoria { }
    public class CategoriaMetadado
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor, informe um nome")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlAmigavel { get; set; }
        public int StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual ICollection<CategoriaPublicacao> CategoriaPublicacao { get; set; }
    }
}
