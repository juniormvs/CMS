using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Linq;
using Util;

namespace BLL
{
    public class DepoimentoBll : IDepoimentoBll
    {
        private IDepoimentoDal _depoimentoDal;

        public DepoimentoBll()
        {
            _depoimentoDal = new DepoimentoDal();
        }

        public void Atualizar(Depoimento depoimento)
        {
            if(null != depoimento)
            {
                _depoimentoDal.Update(depoimento);
                _depoimentoDal.SaveChanges();
            }
        }

        public void Excluir(Depoimento depoimento)
        {
            if (null != depoimento)
            {
                _depoimentoDal.Delete(depoimento);
                _depoimentoDal.SaveChanges();
            }
        }

        public IQueryable<Depoimento> Listar()
        {
            return _depoimentoDal.GetAll();
        }

        public IQueryable<Depoimento> ListarAtivos()
        {
            return _depoimentoDal.Get(d => d.StatusId == Constants.STATUS_ATIVO_ID);
        }

        public Depoimento Obter(int id)
        {
            return _depoimentoDal.Find(d => d.Id == id);
        }

        public void Salvar(Depoimento depoimento)
        {
            if (null != depoimento)
            {
                _depoimentoDal.Add(depoimento);
                _depoimentoDal.SaveChanges();
            }
        }
    }
}
