using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Linq;

namespace BLL
{
    public class PessoaBll : IPessoaBll
    {
        private IPessoaDal _pessoaDal;
        public PessoaBll()
        {
            _pessoaDal = new PessoaDal();
        }
        public void Atualizar(Pessoa pessoa)
        {
            if(null != pessoa)
            {
                _pessoaDal.Update(pessoa);
                _pessoaDal.SaveChanges();
                _pessoaDal.Dispose();
            }
        }

        public void Excluir(Pessoa pessoa)
        {
            if (null != pessoa)
            {
                _pessoaDal.Delete(pessoa);
                _pessoaDal.SaveChanges();
                _pessoaDal.Dispose();
            }
        }

        public IQueryable<Pessoa> Listar()
        {
            return _pessoaDal.GetAll();
        }

        public Pessoa Obter(int id)
        {
            return _pessoaDal.Find(p => p.Id == id);
        }

        public void Salvar(Pessoa pessoa)
        {
            if (null != pessoa)
            {
                _pessoaDal.Add(pessoa);
                _pessoaDal.SaveChanges();
            }
        }
    }
}
