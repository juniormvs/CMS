using Model;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IImovelBll
    {
        Imovel Obter(int id);
        Imovel ObterPorUrl(string imovel);
        IQueryable<Imovel> Listar();
        IQueryable<Imovel> Listar(Expression<Func<Imovel, bool>> where);
        IQueryable<Imovel> ListarAtivos();
        IQueryable<Imovel> ListarPorContrato(int contratoId);
        IQueryable<Imovel> ListarPorTipo(int tipoId);
        void Excluir(Imovel imovel);
        void ExcluirLogica(Imovel imovel);
        Task<bool> Salvar(Imovel imovel);
        Task<bool> Atualizar(Imovel imovel);
    }
}



