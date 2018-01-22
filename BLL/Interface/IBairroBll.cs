using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface IBairroBll
    {
        IQueryable<Bairro> Listar();
        Bairro Obter(int id);
        void Excluir(Bairro bairro);
        void Salvar(Bairro bairro);
        void Atualizar(Bairro bairro);
        Bairro ObterPorNome(string nome);
    }
}
