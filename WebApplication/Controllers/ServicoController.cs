using BLL;
using BLL.Interface;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Util;

namespace WebApplication.Controllers
{
    public class ServicoController : Controller
    {
        private readonly IServicoBll _servicoBll;
        private readonly IStatusBll _statusBll;

        public ServicoController()
        {
            _servicoBll = new ServicoBll();
            _statusBll = new StatusBll();
        }

        // GET: Servico
        public ActionResult Index()
        {
            return View(_servicoBll.ListarAtivosPorTipo(Constants.ID_TIPO_SERVICO).Where(s => s.Ativo).OrderBy(s => s.Nome));
        }
    }
}