namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.Contador")]
    public partial class Contador
    {
        public int Id { get; set; }

        [Required]
        [StringLength(65)]
        public string Nome { get; set; }

        [StringLength(145)]
        public string Descricao { get; set; }

        [StringLength(45)]
        public string Icone { get; set; }

        public int Valor { get; set; }
    }
}
