using BLL;
using BLL.Interface;
using Model;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IEmpresaBll _empresaBll;
        private readonly IPessoaBll _pessoaBll;

        public ContatoController()
        {
            _pessoaBll = new PessoaBll();
            _empresaBll = new EmpresaBll();
        }

        // GET: Contato
        public ActionResult Index()
        {
            Empresa empresa = _empresaBll.Obter(1);
            return View(empresa);
        }

        
    }
}