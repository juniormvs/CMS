using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface IPerfilPessoaBll
    {
        PerfilPessoa Obter(int id);
        IQueryable<PerfilPessoa> Listar();
        void Excluir(PerfilPessoa perfilPessoa);
        void Salvar(PerfilPessoa perfilPessoa);
        void Atualizar(PerfilPessoa perfilPessoa);
    }
}
