using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Linq;

namespace BLL
{
    public class CidadeBll : ICidadeBll
    {
        private ICidadeDal _cidadeDal;
        
        public CidadeBll()
        {
            _cidadeDal = new CidadeDal();
        }

        public IQueryable<VwCidade> Listar()
        {
            return _cidadeDal.GetAll();
        }
    }
}
