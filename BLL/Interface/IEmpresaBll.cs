using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface IEmpresaBll
    {
        Empresa Obter(int id);
        IQueryable<Empresa> Listar();
        void Excluir(Empresa empresa);
        void Salvar(Empresa empresa);
        void Atualizar(Empresa empresa);
    }
}
