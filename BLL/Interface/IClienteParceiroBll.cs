using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface IClienteParceiroBll
    {
        ClienteParceiro Obter(int id);
        IQueryable<ClienteParceiro> Listar();
        IQueryable<ClienteParceiro> ListarAtivos();
        void Excluir(ClienteParceiro clienteParceiro);
        void Salvar(ClienteParceiro clienteParceiro);
        void Atualizar(ClienteParceiro clienteParceiro);
    }
}
