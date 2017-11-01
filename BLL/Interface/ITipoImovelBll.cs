using Model;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Interface
{
    public interface ITipoImovelBll
    {
        TipoImovel Obter(int id);
        TipoImovel ObterPorUrl(string tipoImovel);
        IQueryable<TipoImovel> Listar();
        void Excluir(TipoImovel tipoImovel);
        void Salvar(TipoImovel tipoImovel);
        void Atualizar(TipoImovel tipoImovel);
    }
}
