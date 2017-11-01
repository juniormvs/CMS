using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using DAL.Interface;
using DAL;

namespace BLL
{
    public class TipoContratoBll : ITipoContratoBll
    {
        private ITipoContratoDal _tipoContratoDal;

        public TipoContratoBll()
        {
            _tipoContratoDal = new TipoContratoDal();
        }

        public void Atualizar(TipoContrato tipoContrato)
        {
            if(null != tipoContrato)
            {
                _tipoContratoDal.Update(tipoContrato);
                _tipoContratoDal.SaveChanges();
            }
        }

        public void Excluir(TipoContrato tipoContrato)
        {
            if (null != tipoContrato)
            {
                _tipoContratoDal.Delete(tipoContrato);
                _tipoContratoDal.SaveChanges();
            }
        }

        public IQueryable<TipoContrato> Listar()
        {
            return _tipoContratoDal.GetAll();
        }
        
        public TipoContrato Obter(int id)
        {
            return _tipoContratoDal.Find(x => x.Id == id);
        }

        public TipoContrato ObterPorUrl(string tipoContrato)
        {
            return _tipoContratoDal.Find(x => x.UrlAmigavel.Equals(tipoContrato));
        }

        public void Salvar(TipoContrato tipoContrato)
        {
            if (null != tipoContrato)
            {
                _tipoContratoDal.Add(tipoContrato);
                _tipoContratoDal.SaveChanges();
            }
        }
    }
}
