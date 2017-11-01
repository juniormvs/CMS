using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Linq;
using System;
using System.Linq.Expressions;

namespace BLL
{
    public class StatusBll : IStatusBll
    {
        private readonly IStatusDal _statusDal;

        const int ID_ATIVO = 1;
        const int ID_INATIVO = 2;

        public StatusBll()
        {
            _statusDal = new StatusDal();
        }

        public IQueryable<Status> Listar()
        {
            return _statusDal.Get(s => s.Id == 1 || s.Id == 2 || s.Id == 4);
        }

        public IQueryable<Status> ListarStatusPublicacao()
        {
            return _statusDal.Get(s => s.Id == 3 || s.Id == 4);
        }

        public Status Obter(int id)
        {
            return _statusDal.Find(s => s.Id == id);
        }
    }
}
