using Model;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Interface
{
    public interface ICategoriaPublicacaoBll
    {
        IQueryable<CategoriaPublicacao> ListarPorPublicacao(int publicacaoId);
        IQueryable<CategoriaPublicacao> ListarPorCategoria(int categoriaId);
        void Salvar(CategoriaPublicacao categoriaPublicacao);
        void Salvar(List<CategoriaPublicacao> categorias);
        void Excluir(CategoriaPublicacao categoriaPublicacao);
        void Excluir(ICollection<CategoriaPublicacao> categoriasPublicaccoes);
        void ExcluirPorPublicacao(int id);
    }
}
