using BLL;
using BLL.Interface;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class LinkController : Controller
    {
        private readonly ILinkBll _linkBll;

        public LinkController()
        {
            _linkBll = new LinkBll();
        }

        // GET: Link
        public ActionResult Index()
        {
            return View(_linkBll.ListarAtivos());
        }
    }
}