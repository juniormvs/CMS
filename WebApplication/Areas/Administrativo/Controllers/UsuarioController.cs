using BLL;
using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Areas.Administrativo.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioBll _usuarioBll;

        public UsuarioController()
        {
            _usuarioBll = new UsuarioBll();
        }

        // GET: Administrativo/Usuario
        public ActionResult Index()
        {
            return View(_usuarioBll.Listar());
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
    }
}
