using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface IImovelDetalheBll
    {
        void Salvar(ImovelDetalhe detalhe);
        void Atualizar(ImovelDetalhe detalhe);
        ImovelDetalhe Obter(int id);
        IQueryable<ImovelDetalhe> ListarPorImovel(int imovelId);
    }
}
