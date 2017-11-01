using Model;
using System.Linq;

namespace BLL.Interface
{
    public interface IImagemPublicacaoBll
    {
        ImagemPublicacao Obter(int id);
        IQueryable<ImagemPublicacao> Listar();
        IQueryable<ImagemPublicacao> ListarPorPublicacao(int publicacaoId);
        void Excluir(ImagemPublicacao imagemPublicacao);
        void Salvar(ImagemPublicacao imagemPublicacao);
        void Atualizar(ImagemPublicacao imagemPublicacao);
    }
}
