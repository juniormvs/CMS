using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Linq;

namespace BLL
{
    public class SlideBll : ISlideBll
    {
        private ISlideDal _slideDal;
        public SlideBll()
        {
            _slideDal = new SlideDal();
        }
        public void Atualizar(Slide slide)
        {
            if(null != slide)
            {
                _slideDal.Update(slide);
                _slideDal.SaveChanges();
            }
        }

        public void Excluir(Slide slide)
        {
            if (null != slide)
            {
                _slideDal.Delete(slide);
                _slideDal.SaveChanges();
            }
        }

        public IQueryable<Slide> Listar()
        {
            return _slideDal.GetAll();
        }

        public Slide Obter(int id)
        {
            return _slideDal.Find(s => s.Id == id);
        }

        public void Salvar(Slide slide)
        {
            if (null != slide)
            {
                _slideDal.Add(slide);
                _slideDal.SaveChanges();
            }
        }
    }
}
