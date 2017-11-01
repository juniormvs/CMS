using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Linq;

namespace BLL
{
    public class TipoContatoBll : ITipoContatoBll
    {
        private ITipoContatoDal _tipoDal;
        public TipoContatoBll()
        {
            _tipoDal = new TipoContatoDal();
        }
        public IQueryable<TipoContato> Listar()
        {
            return _tipoDal.GetAll();
        }

        public IQueryable<TipoContato> ListarAtivos()
        {
            return _tipoDal.GetAll();
        }

        public TipoContato Obter(int id)
        {
            return _tipoDal.Find(t => t.Id == id);
        }
    }
}
