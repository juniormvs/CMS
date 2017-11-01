using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface IServicoBll
    {
        Servico Obter(int id);
        IQueryable<Servico> ListarTodosPorTipo(int tipoId);
        IQueryable<Servico> ListarAtivosPorTipo(int tipoId);
        void Excluir(Servico servico);
        void Salvar(Servico servico);
        void Atualizar(Servico servico);
    }
}
