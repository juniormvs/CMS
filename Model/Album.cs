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
    
    public partial class Album
    {
        public Album()
        {
            this.ImagemAlbum = new HashSet<ImagemAlbum>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlAmigavel { get; set; }
        public int StatusId { get; set; }
        public int CategoriaId { get; set; }
        public bool PostarNoFacebook { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<ImagemAlbum> ImagemAlbum { get; set; }
    }
}
