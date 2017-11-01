using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(TipoContratoMetadado))]
    public partial class TipoContrato { }
    public class TipoContratoMetadado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UrlAmigavel { get; set; }

        public virtual ICollection<Imovel> Imovel { get; set; }
    }
}
