using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using ServicoExterno;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Util;

namespace BLL
{
    public class ImovelBll : IImovelBll
    {
        private IImovelDal _imovelDal;

        public ImovelBll()
        {
            _imovelDal = new ImovelDal();
        }

        public async Task<bool> Atualizar(Imovel imovel)
        {
            if(null != imovel)
            {
                await ResolverInformacoes(imovel);

                _imovelDal.Update(imovel);
                _imovelDal.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Excluir(Imovel imovel)
        {
            if (null != imovel)
            {
                _imovelDal.Delete(imovel);
                _imovelDal.SaveChanges();
            }
        }

        public void ExcluirLogica(Imovel imovel)
        {
            if(null != imovel)
            {
                imovel.StatusId = Constants.STATUS_EXCLUIDO_ID;
                imovel.DataExclusao = DateTime.Now;

                _imovelDal.Update(imovel);
                _imovelDal.SaveChanges();
            }
        }

        public IQueryable<Imovel> Listar()
        {
            return _imovelDal.GetAll();
        }

        public IQueryable<Imovel> Listar(Expression<Func<Imovel, bool>> where)
        {
            return _imovelDal.Get(where);
        }
        
        public IQueryable<Imovel> ListarAtivos()
        {
            return _imovelDal.Get(x => x.StatusId == Constants.STATUS_ATIVO_ID);
        }

        public IQueryable<Imovel> ListarPorContrato(int contratoId)
        {
            return _imovelDal.Get(x => x.TipoContratoId == contratoId);
        }

        public IQueryable<Imovel> ListarPorTipo(int tipoId)
        {
            return _imovelDal.Get(x => x.TipoImovelId == tipoId);
        }

        public Imovel Obter(int id)
        {
            return _imovelDal.Find(x => x.Id == id);
        }

        public Imovel ObterPorUrl(string imovel)
        {
            return _imovelDal.Find(x => x.UrlAmigavel.Equals(imovel));
        }

        public async Task<bool> Salvar(Imovel imovel)
        {
            if (null != imovel)
            {
                await ResolverInformacoes(imovel);

                _imovelDal.Add(imovel);
                _imovelDal.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task ResolverInformacoes(Imovel imovel)
        {
            if (imovel?.Endereco != null)
            {
                dynamic retorno;
                GoogleMaps googleMaps = new GoogleMaps();

                retorno = await googleMaps.GetLatitudeLongitude(imovel.Endereco);

                if (retorno.status == "OK")
                {
                    foreach (var data in retorno.results)
                    {
                        imovel.Latitude = data.geometry.location.lat;
                        imovel.Longitude = data.geometry.location.lng;
                    }
                }
            }

            imovel.Titulo = imovel.Titulo.Trim();
            imovel.UrlAmigavel = Texto.FormatarParaURLAmigavel(imovel.Titulo);
            imovel.CidadeUrl = Texto.FormatarParaURLAmigavel(imovel.Cidade);
            imovel.BairroUrl = Texto.FormatarParaURLAmigavel(imovel.Bairro);

            imovel.DataCadastro = DateTime.Now;

            if (string.IsNullOrEmpty(imovel.CentralNegocio))
            {
                imovel.CentralNegocio = @"<p>Para ter mais informa&ccedil;&otilde;es sobre este im&oacute;vel ligue:<br />
                                          <br /><strong>(18) 3217-2771</strong>&nbsp;<strong>CONSULTORIA&nbsp;IMOBILI&Aacute;RIA PRUDENTE</strong>
                                          <br /><br />Avenida Brasil, 2219 Jardim Bela D&aacute;ria - Pres. Prudente/SP<br /> Creci 28.800-J</p>";
            }

        }
    }
}
