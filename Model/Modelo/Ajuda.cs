namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.Ajuda")]
    public partial class Ajuda
    {
        public int Id { get; set; }

        [Required]
        [StringLength(145)]
        public string Titulo { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [StringLength(65535)]
        public string Descricao { get; set; }

        public int AjudaTopicoId { get; set; }

        public virtual AjudaTopico AjudaTopico { get; set; }
    }
}
