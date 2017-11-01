using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BLL
{
    public class MensagemBll : IMensagemBll
    {
        private IMensagemDal _mensagemDal;
        public MensagemBll()
        {
            _mensagemDal = new MensagemDal();
        }
        public void Atualizar(Mensagem mensagem)
        {
            if(mensagem != null)
            {
                _mensagemDal.Update(mensagem);
                _mensagemDal.SaveChanges();
            }
        }

        public void Excluir(Mensagem mensagem)
        {
            if (mensagem != null)
            {
                _mensagemDal.Delete(mensagem);
                _mensagemDal.SaveChanges();
            }
        }

        public IQueryable<Mensagem> Listar()
        {
            return _mensagemDal.GetAll();
        }

        public IQueryable<Mensagem> Listar(Expression<Func<Mensagem, bool>> predicate)
        {
            return _mensagemDal.Get(predicate);
        }

        public Mensagem Obter(int id)
        {
            return _mensagemDal.Find(m => m.Id == id);
        }

        public void Salvar(Mensagem mensagem)
        {
            if (mensagem != null)
            {
                _mensagemDal.Add(mensagem);
                _mensagemDal.SaveChanges();
            }
        }
    }
}
