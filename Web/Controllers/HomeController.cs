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
        public HomeController()
        {
            
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
    }
}
