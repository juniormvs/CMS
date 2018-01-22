using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class PublicacaoPorCategoriaBll : IPublicacaoPorCategoriaBll
    {
        private IPublicacaoPorCategoriaDal _dal;

        public PublicacaoPorCategoriaBll()
        {
            _dal = new PublicacaoPorCategoriaDal();
        }

        public void Excluir(PublicacaoPorCategoria publicacaoPorCategoria)
        {
            _dal.Delete(publicacaoPorCategoria);
            _dal.SaveChanges();
            _dal.Dispose();
        }

        public void Excluir(ICollection<PublicacaoPorCategoria> publicacaoPorCategoria)
        {
            foreach (var item in publicacaoPorCategoria)
            {
                _dal.Delete(item);
                _dal.SaveChanges();
                _dal.Dispose();
            }
        }

        public void ExcluirPorPublicacao(int id)
        {
            var publicacaoPorCategoria = _dal.Get(c => c.PublicacaoId == id).ToList();
            foreach (var item in publicacaoPorCategoria)
            {
                _dal.Delete(item);
                _dal.SaveChanges();
            }
        }

        public IQueryable<PublicacaoPorCategoria> ListarPorCategoria(int categoriaId)
        {
            return _dal.Get(x => x.CategoriaId == categoriaId); 
        }

        public IQueryable<PublicacaoPorCategoria> ListarPorPublicacao(int publicacaoId)
        {
            return _dal.Get(x => x.PublicacaoId == publicacaoId);
        }

        public void Salvar(PublicacaoPorCategoria publicacaoPorCategoria)
        {
            _dal.Add(publicacaoPorCategoria);
            _dal.SaveChanges();
            _dal.Dispose();
        }

        public void Salvar(List<PublicacaoPorCategoria> publicacaoPorCategoria)
        {
            foreach (var item in publicacaoPorCategoria)
            {
                _dal.Add(item);
            }
            _dal.SaveChanges();
        }
    }
}
