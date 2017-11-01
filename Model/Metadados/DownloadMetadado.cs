using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(DownloadMetadado))]
    public partial class Download { }
    public class DownloadMetadado
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string MimeType { get; set; }
        public string Descricao { get; set; }
        public string Arquivo { get; set; }
        public int Status_Id { get; set; }

        public virtual Status Status { get; set; }
    }
}
