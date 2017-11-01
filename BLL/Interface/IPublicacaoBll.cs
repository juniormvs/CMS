using Model;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Interface
{
    public interface IPublicacaoBll
    {
        Publicacao Obter(int id);
        IQueryable<Publicacao> Listar();
        IQueryable<Publicacao> ListarAtivos();
        IQueryable<Publicacao> ListarPorIds(List<int> publicacoesId);
        void Excluir(Publicacao publicacao);
        void Salvar(Publicacao publicacao);
        void Atualizar(Publicacao publicacao);
        Publicacao ObterPorUrl(string publicacao);
        
    }
}
