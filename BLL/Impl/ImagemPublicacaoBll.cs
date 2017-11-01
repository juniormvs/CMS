using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Linq;

namespace BLL
{
    public class ImagemPublicacaoBll : IImagemPublicacaoBll
    {
        private IImagemPublicacaoDal _imagemDal;
        public ImagemPublicacaoBll()
        {
            _imagemDal = new ImagemPublicacaoDal();
        }
        public void Atualizar(ImagemPublicacao imagemPublicacao)
        {
            if(null != imagemPublicacao)
            {
                _imagemDal.Update(imagemPublicacao);
                _imagemDal.SaveChanges();
            }
        }

        public void Excluir(ImagemPublicacao imagemPublicacao)
        {
            if (null != imagemPublicacao)
            {
                _imagemDal.Delete(imagemPublicacao);
                _imagemDal.SaveChanges();
            }
        }

        public IQueryable<ImagemPublicacao> Listar()
        {
            return _imagemDal.GetAll();
        }

        public IQueryable<ImagemPublicacao> ListarPorPublicacao(int publicacaoId)
        {
            return _imagemDal.Get(i => i.PublicacaoId == publicacaoId);
        }

        public ImagemPublicacao Obter(int id)
        {
            return _imagemDal.Find(i => i.Id == id);
        }

        public void Salvar(ImagemPublicacao imagemPublicacao)
        {
            if (null != imagemPublicacao)
            {
                _imagemDal.Add(imagemPublicacao);
                _imagemDal.SaveChanges();
            }
        }
    }
}
