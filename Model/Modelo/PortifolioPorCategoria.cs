namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.PortifolioPorCategoria")]
    public partial class PortifolioPorCategoria
    {
        public int Id { get; set; }

        public int PortifolioId { get; set; }

        public int CategoriaPortifolioId { get; set; }

        public virtual CategoriaPortifolio CategoriaPortifolio { get; set; }

        public virtual Portifolio Portifolio { get; set; }
    }
}
