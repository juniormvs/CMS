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
    
    public partial class Pessoa
    {
        public Pessoa()
        {
            this.ClienteParceiro = new HashSet<ClienteParceiro>();
            this.Contato = new HashSet<Contato>();
            this.Empresa = new HashSet<Empresa>();
            this.Equipe = new HashSet<Equipe>();
            this.RedeSocial = new HashSet<RedeSocial>();
            this.Usuario = new HashSet<Usuario>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Bio { get; set; }
        public string Imagem { get; set; }
        public string Observacao { get; set; }
        public string CpfCnpj { get; set; }
        public string Tipo { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public Nullable<System.DateTime> DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Whatsapp { get; set; }
        public string Email { get; set; }
        public int StatusId { get; set; }
    
        public virtual ICollection<ClienteParceiro> ClienteParceiro { get; set; }
        public virtual ICollection<Contato> Contato { get; set; }
        public virtual ICollection<Empresa> Empresa { get; set; }
        public virtual ICollection<Equipe> Equipe { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<RedeSocial> RedeSocial { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
