namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.ImagemImovel")]
    public partial class ImagemImovel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string Imagem { get; set; }

        public int? Ordem { get; set; }

        public int ImovelId { get; set; }

        public virtual Imovel Imovel { get; set; }
    }
}
