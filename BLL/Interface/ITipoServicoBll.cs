using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface ITipoServicoBll
    {
        TipoServico Obter(int id);
        IQueryable<TipoServico> Listar();
        IQueryable<TipoServico> ListarAtivos();
        
    }
}
