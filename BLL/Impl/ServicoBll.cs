using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Linq;
using Util;

namespace BLL
{
    public class ServicoBll : IServicoBll
    {
        private IServicoDal _servicoDal;

        public ServicoBll()
        {
            _servicoDal = new ServicoDal();
        }

        public void Atualizar(Servico servico)
        {
            if(null != servico)
            {
                _servicoDal.Update(servico);
                _servicoDal.SaveChanges();
            }
        }

        public void Excluir(Servico servico)
        {
            if (null != servico)
            {
                _servicoDal.Delete(servico);
                _servicoDal.SaveChanges();
            }
        }

        public IQueryable<Servico> ListarAtivosPorTipo(int tipoId)
        {
            return _servicoDal.Get(s => s.TipoId == tipoId).Where(s => s.Ativo);
        }

        public IQueryable<Servico> ListarTodosPorTipo(int tipoId)
        {
            return _servicoDal.Get(s => s.TipoId == tipoId);
        }

        public Servico Obter(int id)
        {
            return _servicoDal.Find(s => s.Id == id);
        }

        public void Salvar(Servico servico)
        {
            if (null != servico)
            {
                _servicoDal.Add(servico);
                _servicoDal.SaveChanges();
            }
        }
    }
}
