using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Linq;
using Util;

namespace BLL
{
    public class LinkBll : ILinkBll
    {
        private ILinkDal _linkDal;
        public LinkBll()
        {
            _linkDal = new LinkDal();
        }
        public void Atualizar(Link link)
        {
            if(link != null)
            {
                _linkDal.Update(link);
                _linkDal.SaveChanges();
            }
        }

        public void Excluir(Link link)
        {
            if (link != null)
            {
                _linkDal.Delete(link);
                _linkDal.SaveChanges();
            }
        }

        public IQueryable<Link> Listar()
        {
            return _linkDal.GetAll();
        }

        public IQueryable<Link> ListarAtivos()
        {
            return _linkDal.Get(l => l.Ativo);
        }

        public Link Obter(int id)
        {
            return _linkDal.Find(l => l.Id == id);
        }

        public void Salvar(Link link)
        {
            if (link != null)
            {
                _linkDal.Add(link);
                _linkDal.SaveChanges();
            }
        }
    }
}
