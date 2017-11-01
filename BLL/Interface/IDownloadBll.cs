using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface IDownloadBll
    {
        Download Obter(int id);
        IQueryable<Download> Listar();
        IQueryable<Download> ListarAtivos();
        void Excluir(Download download);
        void Salvar(Download download);
        void Atualizar(Download download);
    }
}
