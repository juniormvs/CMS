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
    
    public partial class Link
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Url { get; set; }
        public string Target { get; set; }
        public int StatusId { get; set; }
    
        public virtual Status Status { get; set; }
    }
}