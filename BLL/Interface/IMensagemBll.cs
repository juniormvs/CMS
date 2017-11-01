using Model;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BLL.Interface
{
    public interface IMensagemBll
    {
        Mensagem Obter(int id);
        IQueryable<Mensagem> Listar();
        IQueryable<Mensagem> Listar(Expression<Func<Mensagem, bool>> predicate);
        void Excluir(Mensagem mensagem);
        void Salvar(Mensagem mensagem);
        void Atualizar(Mensagem mensagem);
    }
}
