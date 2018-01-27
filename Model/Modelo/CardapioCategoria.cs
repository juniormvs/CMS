namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.CardapioCategoria")]
    public partial class CardapioCategoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CardapioCategoria()
        {
            Cardapio = new HashSet<Cardapio>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(65)]
        public string Titulo { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Descricao { get; set; }

        [StringLength(65)]
        public string Imagem { get; set; }

        public bool Bebida { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cardapio> Cardapio { get; set; }
    }
}
