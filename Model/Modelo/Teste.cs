using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("cms-mainsoftware.Teste")]
    public partial class Teste
    {
        [Column(name:"id")]
        public int Id { get; set; }

        [Column(name: "teste_nome", TypeName = "text")]
        public string Nome { get; set; }

        [Column(name: "teste_desc", TypeName ="text")]
        public string Descricacao { get; set; }
    }
}
