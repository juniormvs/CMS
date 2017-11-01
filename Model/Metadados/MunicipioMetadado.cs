using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(MunicipioMetadado))]
    public partial class Municipio { }
    public class MunicipioMetadado
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }
        public string UrlAmigavel { get; set; }

        public virtual ICollection<Imovel> Imovel { get; set; }
    }
}
