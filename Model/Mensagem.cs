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
    
    public partial class Mensagem
    {
        public int Id { get; set; }
        public string Remetente { get; set; }
        public string Email { get; set; }
        public string Assunto { get; set; }
        public string Telefone { get; set; }
        public string Conteudo { get; set; }
        public System.DateTime Data { get; set; }
        public bool Lida { get; set; }
    }
}