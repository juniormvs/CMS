using Model;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Interface
{
    public interface ICategoriaBll
    {
        Categoria Obter(int id);
        Categoria ObterPorUrl(string categoria);
        IQueryable<Categoria> ListarTodos();
        IQueryable<Categoria> ListarAtivos();
        IQueryable<Categoria> Listar(List<int> ids);
        void Excluir(Categoria categoria);
        void Salvar(Categoria categoria);
        void Atualizar(Categoria categoria);
        
    }
}
