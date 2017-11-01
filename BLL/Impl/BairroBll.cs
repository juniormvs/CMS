using BLL.Interface;
using DAL.Impl;
using DAL.Interface;
using Model;
using System.Linq;

namespace BLL
{
    public class BairroBll : IBairroBll
    {
        IBairroDal _bairroDal;

        public BairroBll()
        {
            _bairroDal = new BairroDal();
        }

        public IQueryable<VwBairro> Listar()
        {
            return _bairroDal.GetAll();
        }
    }
}
