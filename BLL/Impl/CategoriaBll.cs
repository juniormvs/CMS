using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace BLL
{
    public class CategoriaBll : ICategoriaBll
    {
        private ICategoriaDal _categoriaDal;
        public CategoriaBll()
        {
            _categoriaDal = new CategoriaDal();
        }
        public void Atualizar(Categoria categoria)
        {
            if(null != categoria)
            {
                _categoriaDal.Update(categoria);
                _categoriaDal.SaveChanges();
            }
        }

        public void Excluir(Categoria categoria)
        {
            if (null != categoria)
            {
                _categoriaDal.Delete(categoria);
                _categoriaDal.SaveChanges();
            }
        }

        public IQueryable<Categoria> ListarTodos()
        {
            return _categoriaDal.GetAll();
        }

        public IQueryable<Categoria> ListarAtivos()
        {
            return _categoriaDal.Get(c => c.StatusId == Constants.STATUS_ATIVO_ID);
        }

        public Categoria Obter(int id)
        {
            return _categoriaDal.Find(c => c.Id == id);
        }

        public void Salvar(Categoria categoria)
        {
            if(null != categoria)
            {
                _categoriaDal.Add(categoria);
                _categoriaDal.SaveChanges();
            }
        }

        public IQueryable<Categoria> Listar(List<int> ids)
        {
            return _categoriaDal.Get(c => ids.Contains(c.Id));
        }

        public Categoria ObterPorUrl(string categoria)
        {
            return _categoriaDal.Find(c => c.UrlAmigavel.Equals(categoria));
        }
    }
}
