using BLL;
using BLL.Interface;
using System.Web.Mvc;
using Util;

namespace Web.Areas.Administrativo.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private IUsuarioBll _usuarioBll;

        public UsuarioController()
        {
            _usuarioBll = new UsuarioBll();
        }
        

        #region CRUD
        // GET: Administrativo/Usuario
        public ActionResult Index()
        {
            return View();
        }

        // GET: Administrativo/Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administrativo/Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrativo/Usuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrativo/Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administrativo/Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrativo/Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administrativo/Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        private void ExibirMensagem(string mensagem, string tipo)
        {
            TempData[Constants.MENSAGEM] = mensagem;
            TempData[Constants.CSS_CLASS] = tipo;
        }
    }
}
