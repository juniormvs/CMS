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
    
    public partial class ImoveInformacao
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
        public string Disponibilidade { get; set; }
        public bool Exclusividade { get; set; }
        public bool Autorizacao { get; set; }
        public bool Averbada { get; set; }
        public bool Escriturada { get; set; }
        public bool Financiamento { get; set; }
        public bool ComPlaca { get; set; }
        public string LocalChave { get; set; }
        public string Informacao { get; set; }
        public int ImovelId { get; set; }
    
        public virtual Imovel Imovel { get; set; }
    }
}