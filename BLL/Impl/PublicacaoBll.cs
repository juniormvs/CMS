using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System.Linq;
using Util;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class PublicacaoBll : IPublicacaoBll
    {
        private IPublicacaoDal _publicacaoDal;

        public PublicacaoBll()
        {
            _publicacaoDal = new PublicacaoDal();
        }
        public void Atualizar(Publicacao publicacao)
        {
            if(publicacao != null)
            {
                _publicacaoDal.Update(publicacao);
                _publicacaoDal.SaveChanges();
                _publicacaoDal.Dispose();
            }
        }
        
        public void Excluir(Publicacao publicacao)
        {
            if (publicacao != null)
            {
                _publicacaoDal.Delete(publicacao);
                _publicacaoDal.SaveChanges();
                _publicacaoDal.Dispose();
            }
        }

        public IQueryable<Publicacao> Listar()
        {
            return _publicacaoDal.GetAll();
        }

        public IQueryable<Publicacao> ListarAtivos()
        {
            return _publicacaoDal.Get(p => p.StatusId == Constants.STATUS_PUBLICADO_ID);
        }

        public Publicacao Obter(int id)
        {
            return _publicacaoDal.Find(p => p.Id == id);
        }

        public Publicacao ObterPorUrl(string publicacao)
        {
            return _publicacaoDal.Find(p => p.UrlAmigavel.Equals(publicacao));
        }

        public void Salvar(Publicacao publicacao)
        {
            if (publicacao != null)
            {
                _publicacaoDal.Add(publicacao);
                _publicacaoDal.SaveChanges();
                _publicacaoDal.Dispose();
            }
        }

        public IQueryable<Publicacao> ListarPorIds(List<int> publicacoesId)
        {
            return _publicacaoDal.Get(p => publicacoesId.Contains(p.Id)).Where(p => p.StatusId == Constants.STATUS_PUBLICADO_ID);
        }
    }
}
