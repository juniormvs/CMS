using Model;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Interface
{
    public interface IPublicacaoPorCategoriaBll
    {
        IQueryable<PublicacaoPorCategoria> ListarPorPublicacao(int publicacaoId);
        IQueryable<PublicacaoPorCategoria> ListarPorCategoria(int categoriaId);
        void Salvar(PublicacaoPorCategoria publicacaoPorCategoria);
        void Salvar(List<PublicacaoPorCategoria> categorias);
        void Excluir(PublicacaoPorCategoria publicacaoPorCategoria);
        void Excluir(ICollection<PublicacaoPorCategoria> publicacaoPorCategoria);
        void ExcluirPorPublicacao(int id);
    }
}
