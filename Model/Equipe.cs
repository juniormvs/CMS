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
    
    public partial class Equipe
    {
        public int Id { get; set; }
        public string Foto { get; set; }
        public string DocumentoProfissional { get; set; }
        public string Cargo { get; set; }
        public int PessoaId { get; set; }
    
        public virtual Pessoa Pessoa { get; set; }
    }
}
