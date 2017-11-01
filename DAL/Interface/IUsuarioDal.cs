
using Model;

namespace DAL.Interface
{
    public interface IUsuarioDal : IRepositorio<Usuario>
    {
        bool Autenticar(Usuario usuario);
    }
}
