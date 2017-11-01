using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface ISlideBll
    {
        Slide Obter(int id);
        IQueryable<Slide> Listar();
        void Excluir(Slide slide);
        void Salvar(Slide slide);
        void Atualizar(Slide slide);
    }
}
