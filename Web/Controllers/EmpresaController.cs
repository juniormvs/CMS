using BLL;
using BLL.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Util;

namespace Web.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IEmpresaBll _empresaBll;
        private readonly IPessoaBll _pessoaBll;
        private readonly IServicoBll _especialidadeBll;
        private readonly IServicoBll _servicoBll;
        private readonly IStatusBll _statusBll;

        public EmpresaController()
        {
            _pessoaBll = new PessoaBll();
            _empresaBll = new EmpresaBll();
            _statusBll = new StatusBll();
            _servicoBll = new ServicoBll();
            _especialidadeBll = new ServicoBll();
        }

        // GET: Empresa
        public ActionResult Index()
        {
            Empresa empresa = _empresaBll.Obter(1);
            return View(empresa);
        }

        public ActionResult Especialidades()
        {
            return PartialView(_especialidadeBll.ListarAtivosPorTipo(Constants.ID_TIPO_ESPECIALIDADE).OrderBy(x => x.Nome));
        }

        public ActionResult Equipe()
        {
            return PartialView();
        }
    }
}