namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.Bairro")]
    public partial class Bairro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bairro()
        {
            Imovel = new HashSet<Imovel>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(145)]
        public string Nome { get; set; }

        [StringLength(145)]
        public string UrlAmigavel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imovel> Imovel { get; set; }
    }
}
