using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface ILinkBll
    {
        Link Obter(int id);
        IQueryable<Link> Listar();
        IQueryable<Link> ListarAtivos();
        void Excluir(Link link);
        void Salvar(Link link);
        void Atualizar(Link link);
    }
}
