//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CardapioCategoria
    {
        public CardapioCategoria()
        {
            this.Cardapio = new HashSet<Cardapio>();
        }
    
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public bool Bebida { get; set; }
        public int Status_Id { get; set; }
    
        public virtual ICollection<Cardapio> Cardapio { get; set; }
        public virtual Status Status { get; set; }
    }
}
