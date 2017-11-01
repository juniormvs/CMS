using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface IDepoimentoBll
    {
        Depoimento Obter(int id);
        IQueryable<Depoimento> Listar();
        IQueryable<Depoimento> ListarAtivos();
        void Excluir(Depoimento depoimento);
        void Salvar(Depoimento depoimento);
        void Atualizar(Depoimento depoimento);
    }
}
