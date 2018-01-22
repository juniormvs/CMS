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

        public void Atualizar(Bairro bairro)
        {
            if (null != bairro)
            {
                _bairroDal.Update(bairro);
                _bairroDal.SaveChanges();
            }
        }

        public void Excluir(Bairro bairro)
        {
            if (null != bairro)
            {
                _bairroDal.Delete(bairro);
                _bairroDal.SaveChanges();
            }
        }

        public IQueryable<Bairro> Listar()
        {
            return _bairroDal.GetAll();
        }

        public Bairro Obter(int id)
        {
            return _bairroDal.Find(b => b.Id == id);
        }

        public Bairro ObterPorNome(string nome)
        {
            return _bairroDal.Find(b => b.Nome.Equals(nome));
        }

        public void Salvar(Bairro bairro)
        {
            if (null != bairro)
            {
                _bairroDal.Add(bairro);
                _bairroDal.SaveChanges();
            }
        }
    }
}
