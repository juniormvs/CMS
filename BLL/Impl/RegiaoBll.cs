using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class RegiaoBll : IRegiaoBll
    {
        IRegiaoDal _regiaoDal;

        public RegiaoBll()
        {
            _regiaoDal = new RegiaoDal();
        }

        public void Atualizar(Regiao regiao)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Regiao regiao)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Regiao> Listar(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Regiao> ListarAtivos()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Regiao> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Regiao Obter(int id)
        {
            throw new NotImplementedException();
        }

        public Regiao ObterPorUrl(string regiao)
        {
            throw new NotImplementedException();
        }

        public void Salvar(Regiao regiao)
        {
            throw new NotImplementedException();
        }
    }
}
