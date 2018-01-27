namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cms-mainsoftware.ProdutoPorCategoria")]
    public partial class ProdutoPorCategoria
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int ProdutoId { get; set; }

        public int CategoriaProdutoId { get; set; }

        public virtual CategoriaProduto CategoriaProduto { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
