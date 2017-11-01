using System;

namespace Web.Models
{
    public class ImovelApi
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