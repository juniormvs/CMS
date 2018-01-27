namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.Portifolio")]
    public partial class Portifolio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Portifolio()
        {
            ImagemPortifolio = new HashSet<ImagemPortifolio>();
            PortifolioPorCategoria = new HashSet<PortifolioPorCategoria>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(145)]
        public string Nome { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Descricao { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string DadosTecnico { get; set; }

        [StringLength(145)]
        public string Imagem { get; set; }

        [StringLength(145)]
        public string Url { get; set; }

        [StringLength(145)]
        public string UrlAmigavel { get; set; }

        public bool Ativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImagemPortifolio> ImagemPortifolio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PortifolioPorCategoria> PortifolioPorCategoria { get; set; }
    }
}
