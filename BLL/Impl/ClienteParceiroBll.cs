using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL.Interface;
using DAL;
using Util;

namespace BLL
{
    public class ClienteParceiroBll : IClienteParceiroBll
    {
        private IClienteParceiroDal _clienteDal;

        public ClienteParceiroBll()
        {
            _clienteDal = new ClienteParceiroDal();
        }

        public void Atualizar(ClienteParceiro clienteParceiro)
        {
            if(clienteParceiro != null)
            {
                _clienteDal.Update(clienteParceiro);
                _clienteDal.SaveChanges();
            }
        }

        public void Excluir(ClienteParceiro clienteParceiro)
        {
            if (clienteParceiro != null)
            {
                _clienteDal.Delete(clienteParceiro);
                _clienteDal.SaveChanges();
            }
        }

        public IQueryable<ClienteParceiro> Listar()
        {
            return _clienteDal.GetAll();
        }

        public IQueryable<ClienteParceiro> ListarAtivos()
        {
            return _clienteDal.Get(c => c.Pessoa.StatusId == Constants.STATUS_ATIVO_ID);
        }

        public ClienteParceiro Obter(int id)
        {
            return _clienteDal.Find(c => c.Id == id);
        }

        public void Salvar(ClienteParceiro clienteParceiro)
        {
            if (clienteParceiro != null)
            {
                _clienteDal.Add(clienteParceiro);
                _clienteDal.SaveChanges();
            }
        }
    }
}
