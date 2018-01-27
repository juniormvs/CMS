namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.Empresa")]
    public partial class Empresa
    {
        public int Id { get; set; }

        [Required]
        [StringLength(145)]
        public string Nome { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Descricao { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Resumo { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string Endereco { get; set; }

        [StringLength(45)]
        public string Telefone { get; set; }

        [StringLength(45)]
        public string Whatsapp { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(45)]
        public string Imagem { get; set; }

        [StringLength(45)]
        public string Logo { get; set; }

        [Required]
        [StringLength(45)]
        public string TemaPainel { get; set; }

        [StringLength(45)]
        public string Latitute { get; set; }

        [StringLength(45)]
        public string Longitude { get; set; }
    }
}
