using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Linq;
using Util;

namespace BLL
{
    public class DownloadBll : IDownloadBll
    {
        private IDownloadDal _downloadDal;

        public DownloadBll()
        {
            _downloadDal = new DownloadDal();
        }

        public void Atualizar(Download download)
        {
            if(null != download)
            {
                _downloadDal.Update(download);
                _downloadDal.SaveChanges();
            }
        }

        public void Excluir(Download download)
        {
            if (null != download)
            {
                _downloadDal.Delete(download);
                _downloadDal.SaveChanges();
            }
        }

        public IQueryable<Download> Listar()
        {
            return _downloadDal.GetAll();
        }

        public IQueryable<Download> ListarAtivos()
        {
            return _downloadDal.Get(d => d.Ativo);
        }

        public Download Obter(int id)
        {
            return _downloadDal.Find(d => d.Id == id);
        }

        public void Salvar(Download download)
        {
            if (null != download)
            {
                _downloadDal.Add(download);
                _downloadDal.SaveChanges();
            }
        }
    }
}
