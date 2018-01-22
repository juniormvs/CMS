using BLL;
using BLL.Interface;
using Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Util;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class BuscaController : Controller
    {
        IImovelBll _imovelBll;
        ITipoContratoBll _contratoBll;
        ITipoImovelBll _tipoBll;
        IStatusBll _statusBll;
        ICidadeBll _cidadeBll;
        IBairroBll _bairroBll;

        public BuscaController()
        {
            _imovelBll = new ImovelBll();
            _contratoBll = new TipoContratoBll();
            _tipoBll = new TipoImovelBll();
            _statusBll = new StatusBll();
            _cidadeBll = new CidadeBll();
            _bairroBll = new BairroBll();
        }
        // GET: Busca
        public ActionResult Index()
        {
            List<Bairro> bairros = _bairroBll.Listar().ToList();
            ViewBag.BairroUrl = Helper.BairroHelper.MontarListaBairro(bairros);

            List<Cidade> cidades = _cidadeBll.Listar().ToList();
            ViewBag.CidadeUrl = Helper.CidadeHelper.MontarListaCidade(cidades);

            ViewBag.TipoContratoId = new SelectList(_contratoBll.Listar().OrderBy(x => x.Nome), "Id", "Nome");
            ViewBag.TipoImovelId = new SelectList(_tipoBll.Listar().OrderBy(x => x.Nome), "Id", "Nome");
            
            return View();
        }

        public ActionResult Busca([Bind(Include = "Id, TipoContratoId, TipoImovelId, Dormitorio, Suite, Banheiro, Garagem")] Imovel imovel, 
                                string Valor, string Bairro, string Cidade)
        {
            int? id = imovel.Id;
            int? contratoId = imovel.TipoContratoId;
            int? tipoId = imovel.TipoImovelId;
            int? dormitorio = imovel.Dormitorio;
            int? suite = imovel.Suite;
            int? banheiro = imovel.Banheiro;
            int? garagem = imovel.Garagem;

            if (tipoId == 0) tipoId = null;
            if (contratoId == 0) contratoId = null;

            int valorInicial = 0;
            int valorFinal = 10000000;

            if (!string.IsNullOrEmpty(Valor))
            {
                string valorConvertido = Valor.Replace("Valor a partir de R$", string.Empty);
                valorInicial = int.Parse(valorConvertido.Substring(0, valorConvertido.IndexOf(',')));

                valorConvertido = valorConvertido.Replace(valorInicial.ToString(), string.Empty)
                                                 .Replace(", até R$", string.Empty)
                                                 .Replace(", e mais que R$", string.Empty);

                valorFinal = int.Parse(valorConvertido);
            }

            List<Imovel> lista = new List<Imovel>();

            if (id == 0)
            {

                var resultado = _imovelBll.Listar()
                                          .Include(i => i.TipoContrato)
                                          .Include(i => i.TipoImovel)
                                          .Where(i => !string.IsNullOrEmpty(Bairro) ? i.Bairro.Nome == Bairro : true)
                                          //.Where(i => !string.IsNullOrEmpty(Bairro) ? i.Cidade == Cidade : true)
                                          .Where(i => contratoId.HasValue ? i.TipoContratoId == contratoId : true)
                                          .Where(i => tipoId.HasValue ? i.TipoImovelId == tipoId : true)
                                          .Where(i => i.Valor.HasValue ? i.Valor >= valorInicial : true)
                                          .Where(i => i.Valor.HasValue ? i.Valor <= valorFinal : true)
                                          .Where(i => banheiro.HasValue ? i.Banheiro == banheiro : true)
                                          .Where(i => dormitorio.HasValue ? i.Dormitorio == dormitorio : true)
                                          .Where(i => suite.HasValue ? i.Suite == suite : true)
                                          .Where(i => garagem.HasValue ? i.Garagem == garagem : true)
                                          .Where(i => i.StatusId == Constants.STATUS_ATIVO_ID);

                 lista = resultado.OrderByDescending(i => i.Id).ToList();
            }
            else
            {
                var resultado = _imovelBll.Obter(imovel.Id);
                lista.Add(resultado);
            }
            
            return View(lista);
        }

        public ActionResult SideBar()
        {
            List<Bairro> bairros = _bairroBll.Listar().ToList();
            ViewBag.BairroUrl = Helper.BairroHelper.MontarListaBairro(bairros);

            List<Cidade> cidades = _cidadeBll.Listar().ToList();
            ViewBag.CidadeUrl = Helper.CidadeHelper.MontarListaCidade(cidades);

            ViewBag.TipoContratoId = new SelectList(_contratoBll.Listar().OrderBy(x => x.Nome), "Id", "Nome");
            ViewBag.TipoImovelId = new SelectList(_tipoBll.Listar().OrderBy(x => x.Nome), "Id", "Nome");
            
            return PartialView();
        }


        public ActionResult BuscaBeta()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> BuscaAssincrono([Bind(Include = "Id, TipoContratoId, TipoImovelId, Dormitorio, Suite, Banheiro, Garagem")] Imovel imovel,
                                string Valor, string Bairro, string Cidade)
        {
            int? id = imovel.Id;
            int? contratoId = imovel.TipoContratoId;
            int? tipoId = imovel.TipoImovelId;
            int? dormitorio = imovel.Dormitorio;
            int? suite = imovel.Suite;
            int? banheiro = imovel.Banheiro;
            int? garagem = imovel.Garagem;

            
            if (tipoId == 0) tipoId = null;
            if (contratoId == 0) contratoId = null;

            int valorInicial = 0;
            int valorFinal = 10000000;

            if (!string.IsNullOrEmpty(Valor))
            {
                string valorConvertido = Valor.Replace("Valor a partir de R$", string.Empty);
                valorInicial = int.Parse(valorConvertido.Substring(0, valorConvertido.IndexOf(',')));

                valorConvertido = valorConvertido.Replace(valorInicial.ToString(), string.Empty)
                                                 .Replace(", até R$", string.Empty)
                                                 .Replace(", e mais que R$", string.Empty);

                valorFinal = int.Parse(valorConvertido);
            }

            List<Imovel> lista = new List<Imovel>();
            List<ImovelApiViewModel> listaImoveisJson = new List<ImovelApiViewModel>();

            if (id == 0)
            {

                await Task.Run(() =>
                {
                    var resultado = _imovelBll.Listar()
                                              .Include(i => i.TipoContrato)
                                              .Include(i => i.TipoImovel)
                                              .Where(i => !string.IsNullOrEmpty(Bairro) ? i.Bairro.Nome == Bairro : true)
                                              //.Where(i => !string.IsNullOrEmpty(Cidade) ? i.Cidade == Cidade : true)
                                              .Where(i => contratoId.HasValue ? i.TipoContratoId == contratoId : true)
                                              .Where(i => tipoId.HasValue ? i.TipoImovelId == tipoId : true)
                                              .Where(i => i.Valor.HasValue ? i.Valor >= valorInicial : true)
                                              .Where(i => i.Valor.HasValue ? i.Valor <= valorFinal : true)
                                              .Where(i => banheiro.HasValue ? i.Banheiro == banheiro : true)
                                              .Where(i => dormitorio.HasValue ? i.Dormitorio == dormitorio : true)
                                              .Where(i => suite.HasValue ? i.Suite == suite : true)
                                              .Where(i => garagem.HasValue ? i.Garagem == garagem : true)
                                              .Where(i => i.StatusId == Constants.STATUS_ATIVO_ID);

                    lista = resultado.OrderByDescending(i => i.Id).ToList();


                    foreach (var item in lista)
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
                });

            }
            else
            {
                var resultado = _imovelBll.Obter(imovel.Id);
                lista.Add(resultado);
            }

            return Json(listaImoveisJson, JsonRequestBehavior.AllowGet);
        }
    }
}