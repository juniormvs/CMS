using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface IRedeSocialBll
    {
        RedeSocial Obter(int id);
        IQueryable<RedeSocial> Listar();
        IQueryable<RedeSocial> ListarPorPessoa(int pessoaId);
        void Excluir(RedeSocial redeSocial);
        void Salvar(RedeSocial redeSocial);
        void Atualizar(RedeSocial redeSocial);
    }
}
