using BLL;
using BLL.Interface;
using Model;
using System;
using System.Linq;
using System.Web.Mvc;
using Util;

namespace Web.Areas.Administrativo.Controllers
{

    public class CategoriaPublicacaoController : Controller
    {
        private readonly ICategoriaPublicacaoBll _categoriaBll;
        private readonly IStatusBll _statusBll;
        //private static ILog Log { get; set; }
        //ILog log = LogManager.GetLogger(typeof(CategoriaController));

        public CategoriaPublicacaoController()
        {
            _categoriaBll = new CategoriaPublicacaoBll();
            _statusBll = new StatusBll();
        }

        // GET: Administrativo/Categoria
        public ActionResult Index()
        {
            return View(_categoriaBll.ListarTodos().OrderBy(c => c.Nome));
        }

        // GET: Administrativo/Categoria/Details/5
        public ActionResult Details(int id)
        {
            CategoriaPublicacao categoria = _categoriaBll.Obter(id);
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
        public ActionResult Create([Bind(Include = "Id, Nome, Descricao, Ativo")] CategoriaPublicacao categoria)
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
                return View(categoria);
            }
        }

        // GET: Administrativo/Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            CategoriaPublicacao categoriaPublicacao = _categoriaBll.Obter(id);
            if (categoriaPublicacao == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }
            return View(categoriaPublicacao);
        }

        // POST: Administrativo/Categoria/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, Nome, Descricao, Ativo")] CategoriaPublicacao categoriaPublicacao)
        {
            try
            {
                categoriaPublicacao.UrlAmigavel = Texto.FormatarParaURLAmigavel(categoriaPublicacao.Nome);
                _categoriaBll.Atualizar(categoriaPublicacao);
                ExibirMensagem(Mensagens.ATUALIZADO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                //log.Error("Error message: " + e.Message + " - " + e.StackTrace);
                ExibirMensagem(Mensagens.ERRO_AO_ATUALIZAR, Constants.DANGER);
                return View(categoriaPublicacao);
            }
        }

        // GET: Administrativo/Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            CategoriaPublicacao categoriaPublicacao = _categoriaBll.Obter(id);
            if (categoriaPublicacao == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }
            return View(categoriaPublicacao);
        }

        // POST: Administrativo/Categoria/Delete/5
        [HttpPost]
        public ActionResult Delete([Bind(Include = "Id, Nome, Descricao")] CategoriaPublicacao categoriaPublicacao)
        {
            try
            {
                categoriaPublicacao = _categoriaBll.Obter(categoriaPublicacao.Id);
                _categoriaBll.Excluir(categoriaPublicacao);
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
