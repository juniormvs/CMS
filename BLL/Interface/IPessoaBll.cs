using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface IPessoaBll
    {
        Pessoa Obter(int id);
        IQueryable<Pessoa> Listar();
        IQueryable<Pessoa> ListarAtivos();
        IQueryable<Pessoa> ListarPorPerfil(int idPerfil);
        void Excluir(Pessoa pessoa);
        void Salvar(Pessoa pessoa);
        void Atualizar(Pessoa pessoa);
    }
}
