using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(EstadoMetadado))]
    public partial class Estado { }
    public class EstadoMetadado
    {
        public int Id { get; set; }
        public int CodigoUf { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }
        public int Regiao { get; set; }

        public virtual ICollection<Imovel> Imovel { get; set; }
    }
}
