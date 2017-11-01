using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Linq;

namespace BLL
{
    public class EmpresaBll : IEmpresaBll
    {
        private IEmpresaDal _empresaDal;
        public EmpresaBll()
        {
            _empresaDal = new EmpresaDal();
        }
        public void Atualizar(Empresa empresa)
        {
            if(null != empresa)
            {
                _empresaDal.Update(empresa);
                _empresaDal.SaveChanges();
            }
        }

        public void Excluir(Empresa empresa)
        {
            if (null != empresa)
            {
                _empresaDal.Delete(empresa);
                _empresaDal.SaveChanges();
            }
        }

        public IQueryable<Empresa> Listar()
        {
            return _empresaDal.GetAll();
        }

        public Empresa Obter(int id)
        {
            return _empresaDal.Find(e => e.Id == id);
        }

        public void Salvar(Empresa empresa)
        {
            if (null != empresa)
            {
                _empresaDal.Add(empresa);
                _empresaDal.SaveChanges();
            }
        }
    }
}
