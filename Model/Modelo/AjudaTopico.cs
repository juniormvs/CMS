namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.AjudaTopico")]
    public partial class AjudaTopico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AjudaTopico()
        {
            Ajuda = new HashSet<Ajuda>();
            AjudaTopico1 = new HashSet<AjudaTopico>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(145)]
        public string Titulo { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Descricao { get; set; }

        public int AjudaTopicoId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ajuda> Ajuda { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AjudaTopico> AjudaTopico1 { get; set; }

        public virtual AjudaTopico AjudaTopico2 { get; set; }
    }
}
