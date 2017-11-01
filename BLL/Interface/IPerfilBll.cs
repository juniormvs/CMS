using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface IPerfilBll
    {
        Perfil Obter(int id);
        IQueryable<Perfil> Listar();
        void Excluir(Perfil perfil);
        void Salvar(Perfil perfil);
        void Atualizar(Perfil perfil);
    }
}
