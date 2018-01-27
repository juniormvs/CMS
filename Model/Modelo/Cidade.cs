namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.Cidade")]
    public partial class Cidade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cidade()
        {
            Imovel = new HashSet<Imovel>();
        }

        [Column(name: "Id")]
        public int Id { get; set; }

        public int Codigo { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(2)]
        public string Uf { get; set; }

        [StringLength(355)]
        public string UrlAmigavel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imovel> Imovel { get; set; }
    }
}
