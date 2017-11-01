using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Linq;

namespace BLL
{
    public class TipoImovelBll : ITipoImovelBll
    {
        private ITipoImovelDal _tipoImovelDal;

        public TipoImovelBll()
        {
            _tipoImovelDal = new TipoImovelDal();
        }

        public void Atualizar(TipoImovel tipoImovel)
        {
            if(null != tipoImovel)
            {
                _tipoImovelDal.Update(tipoImovel);
                _tipoImovelDal.SaveChanges();
            }
        }

        public void Excluir(TipoImovel tipoImovel)
        {
            if (null != tipoImovel)
            {
                _tipoImovelDal.Delete(tipoImovel);
                _tipoImovelDal.SaveChanges();
            }
        }
        
        public IQueryable<TipoImovel> Listar()
        {
            return _tipoImovelDal.GetAll();
        }

        public TipoImovel Obter(int id)
        {
            return _tipoImovelDal.Find(x => x.Id == id);
        }

        public TipoImovel ObterPorUrl(string tipoImovel)
        {
            return _tipoImovelDal.Find(x => x.UrlAmigavel.Equals(tipoImovel));
        }

        public void Salvar(TipoImovel tipoImovel)
        {
            if (null != tipoImovel)
            {
                _tipoImovelDal.Add(tipoImovel);
                _tipoImovelDal.SaveChanges();
            }
        }
    }
}
