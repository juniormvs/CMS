using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface ITipoContratoBll
    {
        TipoContrato Obter(int id);
        TipoContrato ObterPorUrl(string tipoContrato);
        IQueryable<TipoContrato> Listar();
        void Excluir(TipoContrato tipoContrato);
        void Salvar(TipoContrato tipoContrato);
        void Atualizar(TipoContrato tipoContrato);
    }
}
