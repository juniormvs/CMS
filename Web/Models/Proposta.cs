namespace Web.Models
{
    public class Proposta
    {
        public int ImovelId { get; set; }
        public string UrlAmigavel{ get; set; }
        public string ImovelUrl { get; set; }
        public string ImovelTitulo { get; set; }
        public string Remetente { get; set; }
        public string Destinatario { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Mensagem { get; set; }
    }
}