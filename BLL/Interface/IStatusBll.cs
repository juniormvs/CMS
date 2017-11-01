using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface IStatusBll
    {
        Status Obter(int id);
        IQueryable<Status> Listar();
        IQueryable<Status> ListarStatusPublicacao();
    }
}
