using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace BLL
{
    public class CategoriaPublicacaoBll : ICategoriaPublicacaoBll
    {
        private ICategoriaPublicacaoDal _categoriaDal;
        public CategoriaPublicacaoBll()
        {
            _categoriaDal = new CategoriaDal();
        }
        public void Atualizar(CategoriaPublicacao categoriaPublicacao)
        {
            if(null != categoriaPublicacao)
            {
                _categoriaDal.Update(categoriaPublicacao);
                _categoriaDal.SaveChanges();
            }
        }

        public void Excluir(CategoriaPublicacao categoriaPublicacao)
        {
            if (null != categoriaPublicacao)
            {
                _categoriaDal.Delete(categoriaPublicacao);
                _categoriaDal.SaveChanges();
            }
        }

        public IQueryable<CategoriaPublicacao> ListarTodos()
        {
            return _categoriaDal.GetAll();
        }
        

        public CategoriaPublicacao Obter(int id)
        {
            return _categoriaDal.Find(c => c.Id == id);
        }

        public void Salvar(CategoriaPublicacao categoriaPublicacao)
        {
            if(null != categoriaPublicacao)
            {
                _categoriaDal.Add(categoriaPublicacao);
                _categoriaDal.SaveChanges();
            }
        }

        public IQueryable<CategoriaPublicacao> Listar(List<int> ids)
        {
            return _categoriaDal.Get(c => ids.Contains(c.Id));
        }

        public CategoriaPublicacao ObterPorUrl(string categoriaPublicacao)
        {
            return _categoriaDal.Find(c => c.UrlAmigavel.Equals(categoriaPublicacao));
        }
    }
}
