using BLL;
using BLL.Interface;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class MapaController : Controller
    {
        IImovelBll _imovelBll;
        ITipoContratoBll _contratoBll;
        ITipoImovelBll _tipoBll;
        IStatusBll _statusBll;
        ICidadeBll _cidadeBll;
        IBairroBll _bairroBll;
        
        public MapaController()
        {
            _imovelBll = new ImovelBll();
            _contratoBll = new TipoContratoBll();
            _tipoBll = new TipoImovelBll();
            _statusBll = new StatusBll();
            _cidadeBll = new CidadeBll();
            _bairroBll = new BairroBll();
            
        }

        public ActionResult Index()
        {
            List<Bairro> bairros = _bairroBll.Listar().ToList();
            
            ViewBag.Bairro = Helper.BairroHelper.MontarListaBairro(bairros); 

            ViewBag.TipoContrato = new SelectList(_contratoBll.Listar().OrderBy(x => x.Nome), "Id", "Nome");
            ViewBag.TipoImovel = new SelectList(_tipoBll.Listar().OrderBy(x => x.Nome), "Id", "Nome");
            return View();
        }
    }
}