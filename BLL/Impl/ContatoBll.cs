using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Linq;

namespace BLL
{
    public class ContatoBll : IContatoBll
    {
        private IContatoDal _contatoDal;

        public ContatoBll()
        {
            _contatoDal = new ContatoDal();
        }
        public void Atualizar(Contato contato)
        {
            if(null != contato)
            {
                _contatoDal.Update(contato);
                _contatoDal.SaveChanges();
            }
        }

        public void Excluir(Contato contato)
        {
            if (null != contato)
            {
                _contatoDal.Delete(contato);
                _contatoDal.SaveChanges();
            }
        }

        public IQueryable<Contato> Listar()
        {
            return _contatoDal.GetAll();
        }

        public IQueryable<Contato> ListarPorPessoa(int pessoaId)
        {
            return _contatoDal.Get(c => c.PessoaId == pessoaId);
        }

        public IQueryable<Contato> ListarPorTipo(int tipoId)
        {
            return _contatoDal.Get(c => c.TipoContatoId == tipoId);
        }

        public Contato Obter(int id)
        {
            return _contatoDal.Find(c => c.Id == id);
        }

        public void Salvar(Contato contato)
        {
            if (null != contato)
            {
                _contatoDal.Add(contato);
                _contatoDal.SaveChanges();
            }
        }
    }
}
