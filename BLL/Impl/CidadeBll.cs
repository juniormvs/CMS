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
        private IEstadoBll _ufBll;
        
        public CidadeBll()
        {
            _cidadeDal = new CidadeDal();
            _ufBll = new EstadoBll();
    }

        public IQueryable<Cidade> Listar()
        {
            return _cidadeDal.GetAll();
        }

        public IQueryable<Cidade> Listar(int estadoId)
        {
            Estado estado = _ufBll.Obter(estadoId);
            return Listar(estado.Uf);

        }

        public IQueryable<Cidade> Listar(string uf)
        {
            return _cidadeDal.Get(c => c.Uf.Equals(uf));
        }

        public Cidade ObterPorId(int id)
        {
            return _cidadeDal.Find(c => c.Id.Equals(id));
        }

        public Cidade ObterPorNome(string nome)
        {
            return _cidadeDal.Find(c => c.Nome.Equals(nome));
        }
    }
}
