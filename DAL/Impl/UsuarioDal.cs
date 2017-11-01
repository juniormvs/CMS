using DAL.Interface;
using Model;

namespace DAL
{
    public class UsuarioDal : Repositorio<Usuario>, IUsuarioDal
    {
        public bool Autenticar(Usuario usuario)
        {
            var user = Find(u => u.Email.ToLower().Equals(usuario.Email.ToLower()) && u.Senha.Equals(usuario.Senha));
            
            return user != null;
        }
    }
}
