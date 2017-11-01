using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface IRedeBll
    {
        Rede Obter(int id);
        IQueryable<Rede> Listar();
    }
}
