using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface ICidadeBll
    {
        IQueryable<VwCidade> Listar();
    }
}
