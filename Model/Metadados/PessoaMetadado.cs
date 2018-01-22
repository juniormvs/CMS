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
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Por favor, informe o nome da pessoa")]
        [MinLength(2, ErrorMessage = "O nome deve ter no mínimo 2 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        public string CpfCnpj { get; set; }

        [Display(Name = "Data do Cadastro")]
        public System.DateTime DataCadastro { get; set; }

        [Display(Name = "Data de Nascimento")]
        public Nullable<System.DateTime> DataNascimento { get; set; }

        [Display(Name = "Foto")]
        public string Imagem { get; set; }

        [Display(Name = "Biografia")]
        [AllowHtml]
        public string Bio { get; set; }

        [Display(Name = "Observação")]
        [AllowHtml]
        public string Observacao { get; set; }

        [AllowHtml]
        public string Interesse { get; set; }

        [Display(Name = "Já foi oferecido")]
        [AllowHtml]
        public string Oferecido { get; set; }

        [Display(Name = "Informação adicional")]
        [AllowHtml]
        public string Informacao { get; set; }

        [Display(Name = "Documento Profissional")]
        public string DocumentoProfissional { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um e-mail válido")]
        [MaxLength(180, ErrorMessage = "O e-mail, deve ter no máximo 180 caracteres")]
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public string Skype { get; set; }
        public bool Ativo { get; set; }

        [Display(Name = "Observação do tipo de cadastro")]
        public string ObservacaoTipoCadastro { get; set; }

        [Display(Name = "Site / Rede social")]
        public string Url { get; set; }
        public int PerfilPessoaId { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Imovel> Imovel { get; set; }
        public virtual ICollection<Imovel> Imovel1 { get; set; }
        public virtual PerfilPessoa PerfilPessoa { get; set; }
    }
}
