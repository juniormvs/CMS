using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Linq;

namespace BLL
{
    public class TipoServicoBll : ITipoServicoBll
    {
        private ITipoServicoDal _tipoDal;
        public TipoServicoBll()
        {
            _tipoDal = new TipoServicoDal();
        }
        public IQueryable<TipoServico> Listar()
        {
            return _tipoDal.GetAll();
        }

        public IQueryable<TipoServico> ListarAtivos()
        {
            return _tipoDal.GetAll();
        }

        public TipoServico Obter(int id)
        {
            return _tipoDal.Find(t => t.Id == id);
        }
    }
}
