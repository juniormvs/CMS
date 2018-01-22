using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL.Interface;
using DAL;

namespace BLL
{
    public class PerfilPessoaBll : IPerfilPessoaBll
    {
        private IPerfilPessoaDal _perfilPessoaDal;

        public PerfilPessoaBll()
        {
            _perfilPessoaDal = new PerfilPessoaDal();
        }

        public void Atualizar(PerfilPessoa perfilPessoa)
        {
            if(null != perfilPessoa)
            {
                _perfilPessoaDal.Update(perfilPessoa);
                _perfilPessoaDal.SaveChanges();
            }
        }

        public void Excluir(PerfilPessoa perfilPessoa)
        {
            if (null != perfilPessoa)
            {
                _perfilPessoaDal.Delete(perfilPessoa);
                _perfilPessoaDal.SaveChanges();
            }
        }

        public IQueryable<PerfilPessoa> Listar()
        {
            return _perfilPessoaDal.GetAll();
        }

        public PerfilPessoa Obter(int id)
        {
            return _perfilPessoaDal.Find(p => p.Id == id);
        }

        public void Salvar(PerfilPessoa perfilPessoa)
        {
            if (null != perfilPessoa)
            {
                _perfilPessoaDal.Add(perfilPessoa);
                _perfilPessoaDal.SaveChanges();
            }
        }
    }
}
