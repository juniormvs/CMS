using BLL;
using BLL.Interface;
using Model;
using System;
using System.Linq;
using System.Web.Mvc;
using Util;

namespace WebApplication.Areas.Administrativo.Controllers
{
    public class BairroController : Controller
    {
        IBairroBll _bairroBll;

        public BairroController()
        {
            _bairroBll = new BairroBll();
        }

        // GET: Administrativo/Bairro
        public ActionResult Index()
        {
            return View(_bairroBll.Listar().OrderBy(b => b.Nome));
        }

        // GET: Administrativo/Bairro/Details/5
        public ActionResult Details(int id)
        {
            Bairro bairro = _bairroBll.Obter(id);
            if(bairro == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }
            return View(bairro);
        }

        // GET: Administrativo/Bairro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrativo/Bairro/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id, Nome")] Bairro bairro)
        {
            if(_bairroBll.ObterPorNome(bairro.Nome) != null)
            {
                ExibirMensagem(string.Format("O bairro {0}, já existe. Por favor cadastre um com nome diferente.", bairro.Nome), Constants.DANGER);
                return View(bairro);
            }

            try
            {
                _bairroBll.Salvar(bairro);

                ExibirMensagem(Mensagens.SALVO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                //log.Error("Error message: " + e.Message + " - " + e.StackTrace);
                ExibirMensagem(Mensagens.ERRO_AO_ADICIONAR, Constants.DANGER);
                return View(bairro);
            }
        }

        // GET: Administrativo/Bairro/Edit/5
        public ActionResult Edit(int id)
        {
            Bairro bairro = _bairroBll.Obter(id);
            if (bairro == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }
            return View(bairro);
        }

        // POST: Administrativo/Bairro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Id, Nome")] Bairro bairro)
        {
            try
            {
                _bairroBll.Atualizar(bairro);
                ExibirMensagem(Mensagens.ATUALIZADO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                //log.Error("Error message: " + e.Message + " - " + e.StackTrace);
                ExibirMensagem(Mensagens.ERRO_AO_ATUALIZAR, Constants.DANGER);
                return View(bairro);
            }
        }

        // GET: Administrativo/Bairro/Delete/5
        public ActionResult Delete(int id)
        {
            Bairro bairro = _bairroBll.Obter(id);
            if (bairro == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }
            return View(bairro);
        }

        // POST: Administrativo/Bairro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, [Bind(Include = "Id, Nome")] Bairro bairro)
        {
            try
            {
                bairro = _bairroBll.Obter(id);

                _bairroBll.Excluir(bairro);
                
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

        /// <summary>
        /// exibe uma mensagem personalizada para o usuário
        /// </summary>
        /// <param name="mensagem">mensagem informativa para o usuario</param>
        /// <param name="tipo">success / warning / danger</param>
        private void ExibirMensagem(string mensagem, string tipo)
        {
            TempData[Constants.MENSAGEM] = mensagem;
            TempData[Constants.CSS_CLASS] = tipo;
        }
    }
}
