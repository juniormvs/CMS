using System.Web.Mvc;

namespace WebApplication.Areas.Administrativo.Controllers
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