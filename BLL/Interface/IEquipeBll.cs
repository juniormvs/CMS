using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface IEquipeBll
    {
        Equipe Obter(int id);
        IQueryable<Equipe> Listar();
        IQueryable<Equipe> ListarAtivos();
        void Excluir(Equipe equipe);
        void Salvar(Equipe equipe);
        void Atualizar(Equipe equipe);
    }
}
