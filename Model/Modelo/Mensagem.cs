namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.Mensagem")]
    public partial class Mensagem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(145)]
        public string Remetente { get; set; }

        [Required]
        [StringLength(145)]
        public string Email { get; set; }

        [StringLength(60)]
        public string Assunto { get; set; }

        [StringLength(45)]
        public string Telefone { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [StringLength(65535)]
        public string Conteudo { get; set; }

        public DateTime Data { get; set; }

        public bool Lida { get; set; }
    }
}
