using BLL;
using BLL.Interface;
using System.Web.Mvc;
using Util;

namespace Web.Areas.Administrativo.Controllers
{
    public class AdminController : Controller
    {
        private IBairroBll _bairroBll;
        private IImovelBll _imovelBll;

        public AdminController()
        {
            _bairroBll = new BairroBll();
            _imovelBll = new ImovelBll();
        }

        // GET: Administrativo/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ImovelUrl()
        {
            var imoveis = _imovelBll.Listar();
            
            foreach (var item in imoveis)
            {
                if(item.UrlAmigavel == null)
                {
                    //item.UrlAmigavel = Texto.FormatarParaURLAmigavel(item.Titulo);
                    _imovelBll = null;
                    _imovelBll = new ImovelBll();
                    _imovelBll.Atualizar(item);
                }
            }

            return View("Index");
        }
    }
}