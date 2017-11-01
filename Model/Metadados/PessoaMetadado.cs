using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Model
{
    [MetadataType(typeof(PessoaMetadado))]
    public partial class Pessoa { }
    public class PessoaMetadado
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor, informe um nome")]
        public string Nome { get; set; }
        [AllowHtml]
        [Display(Name = "Biografia", ShortName = "Bio")]
        public string Bio { get; set; }
        public string Imagem { get; set; }
        [Display(Name = "Observação")]
        public string Observacao { get; set; }
        public string CpfCnpj { get; set; }
        public string Tipo { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public Nullable<System.DateTime> DataNascimento { get; set; }
        public int StatusId { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Whatsapp { get; set; }
        public string Email { get; set; }

        public virtual Status Status { get; set; }
        public virtual ICollection<RedeSocial> RedeSocial { get; set; }
        public virtual ICollection<Contato> Contato { get; set; }
    }
}
