using System.Web.Mvc;

namespace Web.Areas.Administrativo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Administrativo/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}