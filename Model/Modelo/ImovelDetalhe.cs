namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.ImovelDetalhe")]
    public partial class ImovelDetalhe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ImovelDetalhe()
        {
            DetalhePorImovel = new HashSet<DetalhePorImovel>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string Grupo { get; set; }

        [Required]
        [StringLength(256)]
        public string Descricao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalhePorImovel> DetalhePorImovel { get; set; }
    }
}
