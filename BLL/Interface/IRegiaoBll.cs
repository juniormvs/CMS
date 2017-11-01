using Model;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Interface
{
    public interface IRegiaoBll
    {
        Regiao Obter(int id);
        Regiao ObterPorUrl(string regiao);
        IQueryable<Regiao> ListarTodos();
        IQueryable<Regiao> ListarAtivos();
        IQueryable<Regiao> Listar(List<int> ids);
        void Excluir(Regiao regiao);
        void Salvar(Regiao regiao);
        void Atualizar(Regiao regiao);
    }
}
