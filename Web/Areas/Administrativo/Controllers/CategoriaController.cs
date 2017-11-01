using BLL;
using BLL.Interface;
using Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Util;

namespace Web.Areas.Administrativo.Controllers
{
    [Authorize]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaBll _categoriaBll;
        private readonly IStatusBll _statusBll;
        //private static ILog Log { get; set; }
        //ILog log = LogManager.GetLogger(typeof(CategoriaController));

        public CategoriaController()
        {
            _categoriaBll = new CategoriaBll();
            _statusBll = new StatusBll();
        }

        // GET: Administrativo/Categoria
        public ActionResult Index()
        {
            return View(_categoriaBll.ListarTodos().Include(c => c.Status).OrderBy(c => c.Nome));
        }

        // GET: Administrativo/Categoria/Details/5
        public ActionResult Details(int id)
        {
            Categoria categoria = _categoriaBll.Obter(id);
            if (categoria == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // GET: Administrativo/Categoria/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(_statusBll.Listar(), "Id", "Nome");
            return View();
        }

        // POST: Administrativo/Categoria/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id, Nome, Descricao, Status, StatusId")] Categoria categoria)
        {
            try
            {
                categoria.UrlAmigavel = Texto.FormatarParaURLAmigavel(categoria.Nome);
                _categoriaBll.Salvar(categoria);

                ExibirMensagem(Mensagens.ADICIONADO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                //log.Error("Error message: " + e.Message + " - " + e.StackTrace);
                System.Diagnostics.Debug.WriteLine(e);
                ExibirMensagem(Mensagens.ERRO_AO_ADICIONAR, Constants.DANGER);
                ViewBag.StatusId = new SelectList(_statusBll.Listar(), "Id", "Nome", categoria.StatusId);
                return View(categoria);
            }
        }

        // GET: Administrativo/Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            Categoria categoria = _categoriaBll.Obter(id);
            if (categoria == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(_statusBll.Listar(), "Id", "Nome", categoria.StatusId);
            return View(categoria);
        }

        // POST: Administrativo/Categoria/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, Nome, Descricao, Status, StatusId")] Categoria categoria)
        {
            try
            {
                categoria.UrlAmigavel = Texto.FormatarParaURLAmigavel(categoria.Nome);
                _categoriaBll.Atualizar(categoria);
                ExibirMensagem(Mensagens.ATUALIZADO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                //log.Error("Error message: " + e.Message + " - " + e.StackTrace);
                ExibirMensagem(Mensagens.ERRO_AO_ATUALIZAR, Constants.DANGER);
                ViewBag.StatusId = new SelectList(_statusBll.Listar(), "Id", "Nome", categoria.StatusId);
                return View(categoria);
            }
        }

        // GET: Administrativo/Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            Categoria categoria = _categoriaBll.Obter(id);
            if (categoria == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // POST: Administrativo/Categoria/Delete/5
        [HttpPost]
        public ActionResult Delete([Bind(Include = "Id, Nome, Descricao, Status, StatusId")] Categoria categoria)
        {
            try
            {
                categoria = _categoriaBll.Obter(categoria.Id);
                _categoriaBll.Excluir(categoria);
                ExibirMensagem(Mensagens.EXCLUIDO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                //log.Error("Error message: " + e.Message + " - " + e.StackTrace);
                ExibirMensagem(Mensagens.ERRO_AO_EXCLUIR, Constants.DANGER);
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
