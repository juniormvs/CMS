using Model;
using System.Linq;
using System.Collections.Generic;

namespace BLL.Interface
{
    public interface IImagemImovelBll
    {
        IQueryable<ImagemImovel> Listar();
        IQueryable<ImagemImovel> Listar(int imovelId);
        void Salvar(ImagemImovel imagemImovel);
        void Excluir(ImagemImovel imagemImovel);
        void Atualizar(ImagemImovel imagemImovel);
        ImagemImovel Obter(int id);
        ImagemImovel Obter(string imagem);
        void Salvar(List<ImagemImovel> listaImagens);
    }
}
