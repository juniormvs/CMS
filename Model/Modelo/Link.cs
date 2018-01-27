namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.Link")]
    public partial class Link
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(145)]
        public string Url { get; set; }

        [Required]
        [StringLength(45)]
        public string Target { get; set; }

        public bool Ativo { get; set; }
    }
}
