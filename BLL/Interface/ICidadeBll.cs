using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface ICidadeBll
    {
        IQueryable<Cidade> Listar();
        IQueryable<Cidade> Listar(int estadoId);
        IQueryable<Cidade> Listar(string uf);
        Cidade ObterPorNome(string nome);
        Cidade ObterPorId(int id);
    }
}
