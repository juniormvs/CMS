using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface IUsuarioBll
    {
        Users Obter(string id);
        IQueryable<Users> Listar();
        void Excluir(Users usuario);
        void Salvar(Users usuario);
        void Atualizar(Users usuario);
        bool Autenticar(Users usuario);
        bool RecuperarSenhaPorEmail(Users usuario);

    }
}
