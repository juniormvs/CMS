using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface IUsuarioBll
    {
        Usuario Obter(int id);
        IQueryable<Usuario> Listar();
        IQueryable<Usuario> ListarAtivos();
        void Excluir(Usuario usuario);
        void Salvar(Usuario usuario);
        void Atualizar(Usuario usuario);
        bool Autenticar(Usuario usuario);
        bool RecuperarSenhaPorEmail(Usuario usuario);

    }
}
