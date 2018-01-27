namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.DetalhePorImovel")]
    public partial class DetalhePorImovel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int ImovelId { get; set; }

        public int ImovelDetalheId { get; set; }

        public virtual Imovel Imovel { get; set; }

        public virtual ImovelDetalhe ImovelDetalhe { get; set; }
    }
}
