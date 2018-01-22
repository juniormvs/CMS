using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;

namespace BLL
{
    public class ImovelInformacaoBll : IImovelInformacaoBll
    {
        private readonly IImovelInformacaoDal _dal;

        public ImovelInformacaoBll()
        {
            _dal = new ImovelInformacaoDal();
        }

        public void Atualizar(ImoveInformacao informacao)
        {
            if(null != informacao)
            {
                _dal.Update(informacao);
                _dal.SaveChanges();
            }
        }

        public ImoveInformacao ObterPorId(int id)
        {
            return _dal.Find(x => x.Id == id);
        }

        public ImoveInformacao ObterPorImovel(int imovelId)
        {
            return _dal.Find(x => x.ImovelId == imovelId);
        }

        public void Salvar(ImoveInformacao informacao)
        {
            if (null != informacao)
            {
                _dal.Add(informacao);
                _dal.SaveChanges();
            }
        }
    }
}
