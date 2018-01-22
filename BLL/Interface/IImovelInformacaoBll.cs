using Model;

namespace BLL.Interface
{
    public interface IImovelInformacaoBll
    {
        void Salvar(ImoveInformacao informacao);
        void Atualizar(ImoveInformacao informacao);
        ImoveInformacao ObterPorId(int id);
        ImoveInformacao ObterPorImovel(int imovelId);

    }
}
