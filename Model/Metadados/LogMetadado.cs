using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    [MetadataType(typeof(LogMetadado))]
    public partial class Log { }
    public class LogMetadado
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Datetime { get; set; }
        public string Thread { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}
