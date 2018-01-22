using BLL;
using BLL.Interface;
using Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmpresaBll _empresaBll;
        private readonly IPessoaBll _pessoaBll;
        private readonly IStatusBll _statusBll;
        private readonly ISlideBll _slideBll;
        private readonly ITipoImovelBll _tipoBll;
        private readonly IImovelBll _imovelBll;
        private readonly ITipoContratoBll _contratoBll;
        private readonly IBairroBll _bairroBll;

        private Empresa empresa;

        public HomeController()
        {
            _slideBll = new SlideBll();
            _pessoaBll = new PessoaBll();
            _empresaBll = new EmpresaBll();
            _statusBll = new StatusBll();
            _tipoBll = new TipoImovelBll();
            _imovelBll = new ImovelBll();
            _contratoBll = new TipoContratoBll();
            _bairroBll = new BairroBll();

            empresa = _empresaBll.Obter(1);
        }

        // GET: Home
        public ActionResult Index()
        {
            List<Bairro> bairros = _bairroBll.Listar().ToList();

            ViewBag.BairroUrl = Helper.BairroHelper.MontarListaBairro(bairros);
            ViewBag.TipoContratoId = new SelectList(_contratoBll.Listar().OrderBy(x => x.Nome), "Id", "Nome");
            ViewBag.TipoImovelId = new SelectList(_tipoBll.Listar().OrderBy(x => x.Nome), "Id", "Nome");
            
            return View();
        }
        
        public ActionResult Header()
        {
            return PartialView(empresa);
        }

        public ActionResult Menu()
        {
            return PartialView(empresa);
        }
        
        public ActionResult MenuTipoImoveisVenda()
        {
            var tipoImoveis = _tipoBll.Listar().ToList();
            List<TipoImovel> listaRetorno = ResolverTiposComImoveis(tipoImoveis, 1);

            return PartialView(listaRetorno.OrderBy(x => x.Nome));
        }

        public ActionResult MenuTipoImoveisAluguel()
        {
            int[] ids = { 1, 2, 3, 6 };

            var tiposImoveis = _tipoBll.Listar()
                                  .Where(x => ids.Contains(x.Id))
                                  .ToList();

            List<TipoImovel> listaRetorno = ResolverTiposComImoveis(tiposImoveis, 2);
            
            return PartialView(listaRetorno.Distinct().OrderBy(x => x.Nome));
        }

        private List<TipoImovel> ResolverTiposComImoveis(List<TipoImovel> tipoImoveis, int idTipoContrato)
        {
            var imoveis = _imovelBll.ListarPorContrato(idTipoContrato).ToList();

            var joinImoveisTipo = tipoImoveis.Join(imoveis, ret => ret.Id, im => im.TipoImovelId, (ret, im) => new
            {
                Id = ret.Id,
                Nome = ret.Nome,
                UrlAmigavel = ret.UrlAmigavel
            });
            joinImoveisTipo = joinImoveisTipo.Distinct();

            List<TipoImovel> listaRetorno = new List<TipoImovel>();

            foreach (var item in joinImoveisTipo)
            {
                TipoImovel tipoImovel = new TipoImovel()
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    UrlAmigavel = item.UrlAmigavel
                };

                listaRetorno.Add(tipoImovel);
            }

            return listaRetorno;
        }

        public ActionResult Slide()
        {
            IQueryable<Slide> lista = _slideBll.Listar();
            ViewBag.QuantidadeSlide = lista.Count();

            return PartialView(lista);
        }

        public ActionResult Imoveis()
        {
            return PartialView(_imovelBll.ListarAtivos()
                                         .Include(x => x.TipoImovel)
                                         .Include(x => x.TipoContrato)
                                         .Include(x => x.Cidade)
                                         .Include(x => x.Bairro)
                                         .OrderByDescending(x => x.Id)
                                         .Take(15));
        }

        public ActionResult Corretores()
        {
            return PartialView(_pessoaBll.Listar());
        }

        public ActionResult SideBar()
        {
            return PartialView();
        }

        public ActionResult Footer()
        {
            return PartialView(empresa);
        }
    }
}
