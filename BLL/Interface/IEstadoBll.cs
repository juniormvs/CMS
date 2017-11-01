using Model;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Interface
{
    public interface IEstadoBll
    {
        Estado Obter(int id);
        Estado ObterPorUrl(string estado);
        Estado ObterPorUf(string uf);
        IQueryable<Estado> Listar();
        void Excluir(Estado estado);
        void Salvar(Estado estado);
        void Atualizar(Estado estado);
    }
}
