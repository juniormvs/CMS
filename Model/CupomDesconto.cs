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
    
    public partial class CupomDesconto
    {
        public CupomDesconto()
        {
            this.ClienteParceiro = new HashSet<ClienteParceiro>();
        }
    
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Codigo { get; set; }
        public Nullable<System.DateTime> DataValidade { get; set; }
        public string Descricao { get; set; }
        public string TermosCondicoes { get; set; }
        public int StatusId { get; set; }
    
        public virtual Status Status { get; set; }
        public virtual ICollection<ClienteParceiro> ClienteParceiro { get; set; }
    }
}
