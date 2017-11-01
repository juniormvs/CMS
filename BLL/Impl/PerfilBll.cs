using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Linq;

namespace BLL
{
    public class PerfilBll : IPerfilBll
    {
        private IPerfilDal _perfilDal;
        public PerfilBll()
        {
            _perfilDal = new PerfilDal();
        }
        public void Atualizar(Perfil perfil)
        {
            if(perfil != null)
            {
                _perfilDal.Update(perfil);
                _perfilDal.SaveChanges();
            }
        }

        public void Excluir(Perfil perfil)
        {
            if (perfil != null)
            {
                _perfilDal.Delete(perfil);
                _perfilDal.SaveChanges();
            }
        }

        public IQueryable<Perfil> Listar()
        {
            return _perfilDal.GetAll();
        }

        public Perfil Obter(int id)
        {
            return _perfilDal.Find(p => p.Id == id);
        }

        public void Salvar(Perfil perfil)
        {
            if (perfil != null)
            {
                _perfilDal.Add(perfil);
                _perfilDal.SaveChanges();
            }
        }
    }
}
