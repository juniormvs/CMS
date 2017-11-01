using BLL.Interface;
using DAL.Impl;
using DAL.Interface;
using Model;
using System.Linq;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ImagemImovelBll : IImagemImovelBll
    {
        IImagemImovelDal _dal;

        public ImagemImovelBll()
        {
            _dal = new ImagemImovelDal();
        }

        public void Atualizar(ImagemImovel imagemImovel)
        {
            if(imagemImovel != null)
            {
                _dal.Update(imagemImovel);
                _dal.SaveChanges();
                _dal.Dispose();
            }
        }

        public void Excluir(ImagemImovel imagemImovel)
        {
            if (imagemImovel != null)
            {
                _dal.Delete(imagemImovel);
                _dal.SaveChanges();
                _dal.Dispose();
            }
        }

        public IQueryable<ImagemImovel> Listar()
        {
            return _dal.GetAll();
        }

        public IQueryable<ImagemImovel> Listar(int imovelId)
        {
            return _dal.Get(x => x.ImovelId == imovelId);
        }

        public ImagemImovel Obter(int id)
        {
            return _dal.Find(x => x.Id == id);
        }

        public ImagemImovel Obter(string imagem)
        {
            return _dal.Find(x => x.Imagem.Equals(imagem));
        }

        public void Salvar(ImagemImovel imagemImovel)
        {
            if (imagemImovel != null)
            {
                _dal.Add(imagemImovel);
                _dal.SaveChanges();
                _dal.Dispose();
            }
        }

        public void Salvar(List<ImagemImovel> listaImagens)
        {
            foreach (var item in listaImagens)
            {
                _dal.Add(item);
            }
            _dal.SaveChanges();
            _dal.Dispose();
        }
    }
}
