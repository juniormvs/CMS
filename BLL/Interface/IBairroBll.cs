using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface IBairroBll
    {
        IQueryable<VwBairro> Listar();
    }
}
