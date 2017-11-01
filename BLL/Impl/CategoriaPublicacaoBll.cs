using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BLL
{
    public class CategoriaPublicacaoBll : ICategoriaPublicacaoBll
    {
        private ICategoriaPublicacaoDal _dal;

        public CategoriaPublicacaoBll()
        {
            _dal = new CategoriaPublicacaoDal();
        }

        public void Excluir(CategoriaPublicacao categoriaPublicacao)
        {
            _dal.Delete(categoriaPublicacao);
            _dal.SaveChanges();
            _dal.Dispose();
        }

        public void Excluir(ICollection<CategoriaPublicacao> categoriasPublicaccoes)
        {
            foreach (var item in categoriasPublicaccoes)
            {
                _dal.Delete(item);
                _dal.SaveChanges();
                _dal.Dispose();
            }
        }

        public void ExcluirPorPublicacao(int id)
        {
            var categoriasPublicacoes = _dal.Get(c => c.PublicacaoId == id).ToList();
            foreach (var item in categoriasPublicacoes)
            {
                _dal.Delete(item);
                _dal.SaveChanges();
            }
        }

        public IQueryable<CategoriaPublicacao> ListarPorCategoria(int categoriaId)
        {
            return _dal.Get(x => x.CategoriaId == categoriaId); 
        }

        public IQueryable<CategoriaPublicacao> ListarPorPublicacao(int publicacaoId)
        {
            return _dal.Get(x => x.PublicacaoId == publicacaoId);
        }

        public void Salvar(CategoriaPublicacao categoriaPublicacao)
        {
            _dal.Add(categoriaPublicacao);
            _dal.SaveChanges();
            _dal.Dispose();
        }

        public void Salvar(List<CategoriaPublicacao> categorias)
        {
            foreach (var item in categorias)
            {
                _dal.Add(item);
            }
            _dal.SaveChanges();
        }
    }
}
