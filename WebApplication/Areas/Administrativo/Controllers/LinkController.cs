using BLL;
using BLL.Interface;
using Model;
using System;
using System.Linq;
using System.Web.Mvc;
using Util;

namespace WebApplication.Areas.Administrativo.Controllers
{
    public class LinkController : Controller
    {
        private readonly ILinkBll _linkBll;

        public LinkController()
        {
            _linkBll = new LinkBll();
        }

        // GET: Administrativo/Link
        public ActionResult Index()
        {
            return View(_linkBll.Listar().OrderBy(x => x.Titulo));
        }

        // GET: Administrativo/Link/Details/5
        public ActionResult Details(int id)
        {
            Link link = _linkBll.Obter(id);
            if(link == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }
            return View(link);
        }

        // GET: Administrativo/Link/Create
        public ActionResult Create()
        {
            //ViewBag.StatusId = new SelectList(_statusBll.Listar(), "Id", "Nome");

            return View();
        }

        // POST: Administrativo/Link/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id, Titulo, Url, Target, Ativo")] Link link)
        {
            try
            {
                _linkBll.Salvar(link);
                ExibirMensagem(Mensagens.ADICIONADO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                ExibirMensagem(Mensagens.ERRO_AO_ADICIONAR, Constants.DANGER);
                
                return View(link);
            }
        }

        // GET: Administrativo/Link/Edit/5
        public ActionResult Edit(int id)
        {
            Link link = _linkBll.Obter(id);
            if (link == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }
            
            return View(link);
        }

        // POST: Administrativo/Link/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, Titulo, Url, Target, Ativo")] Link link)
        {
            try
            {
                _linkBll.Atualizar(link);
                ExibirMensagem(Mensagens.ATUALIZADO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                ExibirMensagem(Mensagens.ERRO_AO_ADICIONAR, Constants.DANGER);
                return View(link);
            }
        }

        // GET: Administrativo/Link/Delete/5
        public ActionResult Delete(int id)
        {
            Link link = _linkBll.Obter(id);
            if (link == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }
            return View(link);
        }

        // POST: Administrativo/Link/Delete/5
        [HttpPost]
        public ActionResult Delete([Bind(Include = "Id, Titulo, Url, Target, Status, StatusId")] Link link)
        {
            try
            {
                link = _linkBll.Obter(link.Id);
                _linkBll.Excluir(link);
                ExibirMensagem(Mensagens.EXCLUIDO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                ExibirMensagem(Mensagens.ERRO_AO_EXCLUIR, Constants.DANGER);
                return View(link);
            }
        }

        private void ExibirMensagem(string mensagem, string tipo)
        {
            TempData[Constants.MENSAGEM] = mensagem;
            TempData[Constants.CSS_CLASS] = tipo;
        }
    }
}
