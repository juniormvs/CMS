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
    public class EspecialidadeController : Controller
    {
        private readonly IServicoBll _servicoBll;
        private readonly IStatusBll _statusBll;

        public EspecialidadeController()
        {
            _servicoBll = new ServicoBll();
            _statusBll = new StatusBll();
        }

        // GET: Administrativo/Servico
        public ActionResult Index()
        {
            return View(_servicoBll.ListarTodosPorTipo(Constants.ID_TIPO_ESPECIALIDADE).Include(s => s.Status).OrderBy(s => s.Nome));
        }

        // GET: Administrativo/Servico/Details/5
        public ActionResult Details(int id)
        {
            Servico servico = _servicoBll.Obter(id);
            if (servico == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }
            return View(servico);
        }

        // GET: Administrativo/Servico/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(_statusBll.Listar(), "Id", "Nome");
            return View();
        }

        // POST: Administrativo/Servico/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id, Nome, Resumo, Descricao, Icone, Imagem, UrlAmigavel, StatusId, Status")] Servico servico)
        {
            servico.TipoId = Constants.ID_TIPO_ESPECIALIDADE;
            servico.UrlAmigavel = Texto.FormatarParaURLAmigavel(servico.Nome);
            try
            {
                _servicoBll.Salvar(servico);

                ExibirMensagem(Mensagens.ADICIONADO_COM_SUCESSO, Constants.SUCCESS);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                ExibirMensagem(Mensagens.ERRO_AO_ADICIONAR, Constants.DANGER);
                ViewBag.StatusId = new SelectList(_statusBll.Listar(), "Id", "Nome");
                return View(servico);
            }
        }

        // GET: Administrativo/Servico/Edit/5
        public ActionResult Edit(int id)
        {
            Servico servico = _servicoBll.Obter(id);
            if (servico == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(_statusBll.Listar(), "Id", "Nome");
            return View(servico);
        }

        // POST: Administrativo/Servico/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, Nome, Resumo, Descricao, Icone, Imagem, UrlAmigavel, StatusId, Status")] Servico servico)
        {
            servico.TipoId = Constants.ID_TIPO_ESPECIALIDADE;

            try
            {
                _servicoBll.Atualizar(servico);

                ExibirMensagem(Mensagens.ATUALIZADO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                ExibirMensagem(Mensagens.ERRO_AO_ADICIONAR, Constants.DANGER);
                ViewBag.StatusId = new SelectList(_statusBll.Listar(), "Id", "Nome");
                return View(servico);
            }
        }

        // GET: Administrativo/Servico/Delete/5
        public ActionResult Delete(int id)
        {
            Servico servico = _servicoBll.Obter(id);
            if (servico == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }
            return View(servico);
        }

        // POST: Administrativo/Servico/Delete/5
        [HttpPost]
        public ActionResult Delete([Bind(Include = "Id")] Servico servico)
        {
            try
            {
                servico = _servicoBll.Obter(servico.Id);
                _servicoBll.Excluir(servico);
                ExibirMensagem(Mensagens.EXCLUIDO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                ExibirMensagem(Mensagens.ERRO_AO_EXCLUIR, Constants.DANGER);
                ViewBag.StatusId = new SelectList(_statusBll.Listar(), "Id", "Nome");
                return View(servico);
            }
        }

        private void ExibirMensagem(string mensagem, string tipo)
        {
            TempData[Constants.MENSAGEM] = mensagem;
            TempData[Constants.CSS_CLASS] = tipo;
        }
    }
}
