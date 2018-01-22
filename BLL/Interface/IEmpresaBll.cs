using Model;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IEmpresaBll
    {
        Empresa Obter(int id);
        IQueryable<Empresa> Listar();
        void Excluir(Empresa empresa);
        void Salvar(Empresa empresa);
        Task Atualizar(Empresa empresa);
        void AtualizarSkin(Empresa empresa);
    }
}
