using Model;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Interface
{
    public interface ICategoriaPublicacaoBll
    {
        CategoriaPublicacao Obter(int id);
        CategoriaPublicacao ObterPorUrl(string categoriaPublicacao);
        IQueryable<CategoriaPublicacao> ListarTodos();
        IQueryable<CategoriaPublicacao> Listar(List<int> ids);
        void Excluir(CategoriaPublicacao categoriaPublicacao);
        void Salvar(CategoriaPublicacao categoriaPublicacao);
        void Atualizar(CategoriaPublicacao categoriaPublicacao);
        
    }
}
