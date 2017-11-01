using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface ITipoContatoBll
    {
        TipoContato Obter(int id);
        IQueryable<TipoContato> Listar();
        IQueryable<TipoContato> ListarAtivos();
    }
}
