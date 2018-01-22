using System.Web.Mvc;
using Util;

namespace Web.Areas.Administrativo.Controllers
{

    public class DownloadController : Controller
    {
        // GET: Administrativo/Download
        public ActionResult Index()
        {
            return View();
        }

        // GET: Administrativo/Download/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administrativo/Download/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrativo/Download/Create
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

        // GET: Administrativo/Download/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administrativo/Download/Edit/5
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

        // GET: Administrativo/Download/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administrativo/Download/Delete/5
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

        private void ExibirMensagem(string mensagem, string tipo)
        {
            TempData[Constants.MENSAGEM] = mensagem;
            TempData[Constants.CSS_CLASS] = tipo;
        }
    }
}
