using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebApplication.Helper;

namespace WebApplication.Models
{
    public class ImovelViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [AllowHtml]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [AllowHtml]
        [Display(Name = "Central de Negócio")]
        public string CentralNegocio { get; set; }

        [AllowHtml]
        [Display(Name = "Pontos Fortes")]
        public string PontosFortes { get; set; }

        [AllowHtml]
        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        [Display(Name = "Imagem Principal")]
        public string Imagem { get; set; }

        public string UrlAmigavel { get; set; }

        [Display(Name = "Data de Cadastro")]
        public string DataCadastro { get; set; }

        [Display(Name = "Data de Exclusão")]
        public string DataExclusao { get; set; }

        [Display(Name = "Usuário de Exclusão")]
        public string UsuarioExclusao { get; set; }

        [BooleanDisplayValuesAsYesNo]
        public bool Destaque { get; set; }

        public string Valor { get; set; }

        [Display(Name = "IPTU")]
        public string Iptu { get; set; }

        public string Condominio { get; set; }

        public string Taxa { get; set; }

        [AllowHtml]
        [Display(Name = "Observação do Valor")]
        public string ObservacaoValor { get; set; }

        [Display(Name = "Dormitórios")]
        public Nullable<int> Dormitorio { get; set; }

        [Display(Name = "Suítes")]
        public Nullable<int> Suite { get; set; }

        public Nullable<int> Banheiro { get; set; }

        public Nullable<int> Garagem { get; set; }

        [Display(Name = "Acomodações")]
        public Nullable<int> Acomodacoes { get; set; }

        [BooleanDisplayValuesAsYesNo]
        public Nullable<bool> Mobiliado { get; set; }

        [BooleanDisplayValuesAsYesNo]
        [Display(Name = "Em Condomínio")]
        public Nullable<bool> EmCondominio { get; set; }

        [Display(Name = "Ano da Construção")]
        public Nullable<int> AnoConstrucao { get; set; }

        public string Pavimento { get; set; }

        public string Video { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Display(Name = "Endereço Completo")]
        public string EnderecoGoogle { get; set; }

        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        public string Zona { get; set; }

        [Display(Name = "Região")]
        public string Regiao { get; set; }

        [Display(Name = "Ponto de Referencia")]
        public string PontoReferencia { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        [BooleanDisplayValuesAsYesNo]
        [Display(Name = "Gerar Mapa Individual")]
        public Nullable<bool> GerarMapa { get; set; }

        [BooleanDisplayValuesAsYesNo]
        [Display(Name = "Incluir na página de mapa")]
        public Nullable<bool> IncluirNoMapa { get; set; }

        [Display(Name = "Total")]
        public string AreaTotal { get; set; }
        public string UnMedidaTotal { get; set; }

        [Display(Name = "Privativa")]
        public string AreaPrivativa { get; set; }
        public string UnMedidaPrivativa { get; set; }

        [Display(Name = "Construída")]
        public string AreaConstruida { get; set; }
        public string UnMedidaConstruida { get; set; }

        [Display(Name = "Terreno")]
        public string AreaTerreno { get; set; }
        public string UnMedidaTerreno { get; set; }

        [Display(Name = "Terreno Frente")]
        public string TerrenoFrente { get; set; }
        public string UnMedidaTerrenoFrente { get; set; }

        [Display(Name = "Terreno Fundo")]
        public string TerrenoFundo { get; set; }
        public string UnMedidaTerrenoFundo { get; set; }

        [Display(Name = "Terreno Direita")]
        public string TerrenoDireita { get; set; }
        public string UnMedidaTerrenoDireita { get; set; }

        [Display(Name = "Terreno Esquerda")]
        public string TerrenoEsquerrda { get; set; }
        public string UnMedidaTerrenoEsquerda { get; set; }

        [Display(Name = "Nome do Condomínio")]
        public string NomeCondominio { get; set; }

        public int TipoContratoId { get; set; }
        public int TipoImovelId { get; set; }
        public int StatusId { get; set; }
        public int BairroId { get; set; }
        public int CidadeId { get; set; }
        public Nullable<int> CorretorPessoaId { get; set; }
        public Nullable<int> ProprietarioPessoaId { get; set; }
        public string UserId { get; set; }

        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }


        public int IdImovelInformacao { get; set; }

        [Display(Name = "Disponibilidade")]
        public string Disponibilidade { get; set; }

        [BooleanDisplayValuesAsYesNo]
        [Display(Name = "Exclusividade")]
        public bool Exclusividade { get; set; }

        [BooleanDisplayValuesAsYesNo]
        [Display(Name = "Autorização")]
        public bool Autorizacao { get; set; }

        [BooleanDisplayValuesAsYesNo]
        [Display(Name = "Averbada")]
        public bool Averbada { get; set; }

        [BooleanDisplayValuesAsYesNo]
        [Display(Name = "Escriturada")]
        public bool Escriturada { get; set; }

        [BooleanDisplayValuesAsYesNo]
        [Display(Name = "Financiamento")]
        public bool Financiamento { get; set; }

        [BooleanDisplayValuesAsYesNo]
        [Display(Name = "Com Placa")]
        public bool ComPlaca { get; set; }

        [Display(Name = "Local da Chave")]
        public string LocalChave { get; set; }

        [AllowHtml]
        [Display(Name = "Informação Adicional")]
        public string Informacao { get; set; }
        public int ImovelId { get; set; }

        public override string ToString()
        {
            return "Id : " + Id + ", Codigo : " + Codigo + ", Descricao : " + Descricao + ", CentralNegocio : " + CentralNegocio +
                    ", PontosFortes : " + PontosFortes + ", Observacao : " + Observacao + ", Imagem : " + Imagem + ", UrlAmigavel : " + UrlAmigavel +
                    ", DataCadastro : " + DataCadastro + ", DataExclusao : " + DataExclusao + ", UsuarioExclusao : " + UsuarioExclusao +
                    ", Destaque : " + Destaque + ", Valor : " + Valor + ", Iptu : " + Iptu + ", Condominio : " + Condominio + ", Taxa : " + Taxa +
                    ", ObservacaoValor : " + ObservacaoValor + ", Dormitorio : " + Dormitorio + ", Suite : " + Suite + ", Banheiro : " + Banheiro +
                    ", Garagem : " + Garagem + ", Acomodacoes : " + Acomodacoes + ", Mobiliado : " + Mobiliado + ", EmCondominio : " + EmCondominio +
                    ", AnoConstrucao : " + AnoConstrucao + ", Pavimento : " + Pavimento + ", Video : " + Video + ", Cep : " + Cep + ", EnderecoGoogle : " + EnderecoGoogle +
                    ", Logradouro : " + Logradouro + ", Numero : " + Numero + ", Complemento : " + Complemento + ", Zona : " + Zona + ", Regiao : " + Regiao +
                    ", PontoReferencia : " + PontoReferencia + ", Latitude : " + Latitude + ", Longitude : " + Longitude + ", GerarMapa : " + GerarMapa +
                    ", IncluirNoMapa : " + IncluirNoMapa + ", AreaTotal : " + AreaTotal + ", UnMedidaTotal : " + UnMedidaTotal + ", AreaPrivativa : " + AreaPrivativa +
                    ", UnMedidaPrivativa : " + UnMedidaPrivativa + ", AreaConstruida : " + AreaConstruida + ", UnMedidaConstruida : " + UnMedidaConstruida +
                    ", AreaTerreno : " + AreaTerreno + ", UnMedidaTerreno : " + UnMedidaTerreno + ", TerrenoFrente : " + TerrenoFrente +
                    ", UnMedidaTerrenoFrente : " + UnMedidaTerrenoFrente + ", TerrenoFundo : " + TerrenoFundo + ", UnMedidaTerrenoFundo : " + UnMedidaTerrenoFundo +
                    ", TerrenoDireita : " + TerrenoDireita + ", UnMedidaTerrenoDireita : " + UnMedidaTerrenoDireita + ", TerrenoEsquerrda : " + TerrenoEsquerrda +
                    ", UnMedidaTerrenoEsquerda : " + UnMedidaTerrenoEsquerda + ", NomeCondominio : " + NomeCondominio + ", TipoContratoId : " + TipoContratoId +
                    ", TipoImovelId : " + TipoImovelId + ", StatusId : " + StatusId + ", BairroId : " + BairroId + ", CidadeId : " + CidadeId +
                    ", CorretorPessoaId : " + CorretorPessoaId + ", ProprietarioPessoaId : " + ProprietarioPessoaId + ", UserId : " + UserId +
                    ", Bairro : " + Bairro + ", Cidade : " + Cidade + ", Uf : " + Uf + ", IdImovelInformacao : " + IdImovelInformacao +
                    ", Disponibilidade : " + Disponibilidade + ", Exclusividade : " + Exclusividade + ", Autorizacao : " + Autorizacao +
                    ", Averbada : " + Averbada + ", Escriturada : " + Escriturada + ", Financiamento : " + Financiamento + ", ComPlaca : " + ComPlaca +
                    ", LocalChave : " + LocalChave + ", Informacao : " + Informacao + ", ImovelId : " + ImovelId;
        }
    }

    public class ImovelApiViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public Nullable<double> AreaTotal { get; set; }
        public Nullable<double> AreaConstruida { get; set; }
        public Nullable<int> Dormitorio { get; set; }
        public Nullable<int> Suite { get; set; }
        public Nullable<int> Banheiro { get; set; }
        public Nullable<int> Garagem { get; set; }
        public string Endereco { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string TipoImovel { get; set; }
        public string TipoContrato { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string UrlAmigavel { get; set; }

    }
}