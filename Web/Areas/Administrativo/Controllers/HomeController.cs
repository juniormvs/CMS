using System.Web.Mvc;

namespace Web.Areas.Administrativo.Controllers
{

    public class HomeController : Controller
    {
        // GET: Administrativo/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}