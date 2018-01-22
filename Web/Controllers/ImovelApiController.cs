using BLL;
using BLL.Interface;
using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Web.Models;

namespace Web.Controllers
{
    public class ImovelApiController : ApiController
    {
        IImovelBll _imovelBll;
        ITipoContratoBll _contratoBll;
        ITipoImovelBll _tipoBll;
        IStatusBll _statusBll;
        ICidadeBll _cidadeBll;
        IBairroBll _bairroBll;

        public ImovelApiController()
        {
            _imovelBll = new ImovelBll();
            _contratoBll = new TipoContratoBll();
            _tipoBll = new TipoImovelBll();
            _statusBll = new StatusBll();
            _cidadeBll = new CidadeBll();
            _bairroBll = new BairroBll();
        }

        // GET: api/ImovelApi
        /// <summary>
        /// Retorna todos os imoveis cadastrados e com status ativo
        /// </summary>
        /// <returns>json de imoveis</returns>
        public List<ImovelApiViewModel> Get()
        {
            var queryString = this.Request.GetQueryNameValuePairs();

            int? contratoId = null;
            int? tipoId = null;
            string bairro = null;

            if(queryString.Count() > 0)
            {
                foreach (var item in queryString)
                {
                    if (string.IsNullOrEmpty(item.Value))
                    {
                        continue;
                    }

                    switch (item.Key)
                    {
                        case "contrato":
                            contratoId = int.Parse(item.Value);
                            break;
                        case "tipo":
                            tipoId = int.Parse(item.Value);
                            break;
                        case "bairro":
                            bairro = item.Value;
                            break;
                        default:
                            break;
                    }
                }
            }

            List<Imovel> listaImoveis = new List<Imovel>();

            listaImoveis = _imovelBll.ListarAtivos()
                                .Include(i => i.TipoContrato)
                                .Include(i => i.TipoImovel)
                                .Where(i => contratoId.HasValue ? i.TipoContratoId == contratoId : true)
                                .Where(i => tipoId.HasValue ? i.TipoImovelId == contratoId : true)
                                //.Where(i => !string.IsNullOrEmpty(bairro) ? i.BairroUrl == bairro : true)
                                .OrderByDescending(x => x.Id)
                                .ToList();
            
                        
            
            List<ImovelApiViewModel> listaImoveisJson = new List<ImovelApiViewModel>();

            foreach (var item in listaImoveis)
            {
                ImovelApiViewModel api = new ImovelApiViewModel()
                {
                    Id = item.Id,
                    UrlAmigavel = item.UrlAmigavel,
                    Latitude = item.Latitude,
                    Longitude = item.Longitude,
                    Imagem = item.Imagem,
                    Valor = item.Valor,
                    AreaConstruida = item.AreaConstruida,
                    AreaTotal = item.AreaTotal,
                    Banheiro = item.Banheiro,
                    Dormitorio = item.Dormitorio,
                    Suite = item.Suite,
                    Garagem = item.Garagem,
                    Endereco = item.EnderecoGoogle,
                    TipoContrato = item.TipoContrato.Nome,
                    TipoImovel = item.TipoImovel.Nome
                };

                listaImoveisJson.Add(api);
            }

            return listaImoveisJson;
        }

        // GET: api/ImovelApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ImovelApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ImovelApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ImovelApi/5
        public void Delete(int id)
        {
        }
    }
}
