using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Linq;
using Util;

namespace BLL
{
    public class EquipeBll : IEquipeBll
    {
        private IEquipeDal _equipeDal;
        public EquipeBll()
        {
            _equipeDal = new EquipeDal();
        }
        public void Atualizar(Equipe equipe)
        {
            if(null != equipe)
            {
                _equipeDal.Update(equipe);
                _equipeDal.SaveChanges();
            }
        }

        public void Excluir(Equipe equipe)
        {
            if (null != equipe)
            {
                _equipeDal.Delete(equipe);
                _equipeDal.SaveChanges();
            }
        }

        public IQueryable<Equipe> Listar()
        {
            return _equipeDal.GetAll();
        }

        public IQueryable<Equipe> ListarAtivos()
        {
            return _equipeDal.Get(e => e.Pessoa.StatusId == Constants.STATUS_ATIVO_ID);
        }

        public Equipe Obter(int id)
        {
            return _equipeDal.Find(e => e.Id == id);
        }

        public void Salvar(Equipe equipe)
        {
            if (null != equipe)
            {
                _equipeDal.Add(equipe);
                _equipeDal.SaveChanges();
            }
        }
    }
}
