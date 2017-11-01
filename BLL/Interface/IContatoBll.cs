using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface IContatoBll
    {
        Contato Obter(int id);
        IQueryable<Contato> Listar();
        IQueryable<Contato> ListarPorTipo(int tipoId);
        IQueryable<Contato> ListarPorPessoa(int pessoaId);
        void Excluir(Contato contato);
        void Salvar(Contato contato);
        void Atualizar(Contato contato);
    }
}
