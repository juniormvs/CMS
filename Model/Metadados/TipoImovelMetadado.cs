using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(TipoImovelMetadado))]
    public partial class TipoImovel { }
    public class TipoImovelMetadado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UrlAmigavel { get; set; }
        public virtual ICollection<Imovel> Imovel { get; set; }
    }
}
