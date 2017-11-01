using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Linq;

namespace BLL
{
    public class EstadoBll : IEstadoBll
    {
        private IEstadoDal _estadoDal;

        public EstadoBll()
        {
            _estadoDal = new EstadoDal();
        }

        public void Atualizar(Estado estado)
        {
            if(null != estado)
            {
                _estadoDal.Update(estado);
                _estadoDal.SaveChanges();
            }
        }

        public void Excluir(Estado estado)
        {
            if (null != estado)
            {
                _estadoDal.Delete(estado);
                _estadoDal.SaveChanges();
            }
        }

        public IQueryable<Estado> Listar()
        {
            return _estadoDal.GetAll();
        }

        public Estado Obter(int id)
        {
            return _estadoDal.Find(e => e.Id == id);
        }

        public Estado ObterPorUf(string uf)
        {
            return _estadoDal.Find(e => e.Uf.Equals(uf));
        }

        public Estado ObterPorUrl(string estado)
        {
            return _estadoDal.Find(e => e.Nome.Equals(estado));
        }

        public void Salvar(Estado estado)
        {
            if (null != estado)
            {
                _estadoDal.Add(estado);
                _estadoDal.SaveChanges();
            }
        }
    }
}
