using BLL;
using BLL.Interface;
using Model;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using Util;
using WebApplication.Enum;

namespace WebApplication.Areas.Administrativo.Controllers
{
    public class PessoaController : Controller
    {
        IPessoaBll _pessoaBll;
        IPerfilPessoaBll _perfilPessoaBll;

        public PessoaController()
        {
            _pessoaBll = new PessoaBll();
            _perfilPessoaBll = new PerfilPessoaBll();
        }

        // GET: Administrativo/Pessoa
        public ActionResult Index()
        {
            return View(_pessoaBll.Listar().Include(p => p.PerfilPessoa).OrderBy(p => p.Nome));
        }

        public ActionResult Corretor()
        {
            return View(_pessoaBll.Listar().Include(p => p.PerfilPessoa).Where(p => p.PerfilPessoaId == (int)PerfilPessoaEnum.Corretor).OrderBy(p => p.Nome));
        }

        public ActionResult Cliente()
        {
            return View(_pessoaBll.Listar().Include(p => p.PerfilPessoa).Where(p => p.PerfilPessoaId == (int)PerfilPessoaEnum.Cliente).OrderBy(p => p.Nome));
        }

        public ActionResult Proprietario()
        {
            return View(_pessoaBll.Listar().Include(p => p.PerfilPessoa).Where(p => p.PerfilPessoaId == (int)PerfilPessoaEnum.Proprietário).OrderBy(p => p.Nome));
        }

        // GET: Administrativo/Pessoa/Details/5
        public ActionResult Details(int id)
        {
            Pessoa pessoa = _pessoaBll.Obter(id);

            if(null == pessoa)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }

            return View(pessoa);
        }

        // GET: Administrativo/Pessoa/Create
        public ActionResult Create()
        {
            ViewBag.PerfilPessoaId = new SelectList(_perfilPessoaBll.Listar().OrderBy(p => p.Descricao), "Id", "Descricao");
            return View();
        }

        // POST: Administrativo/Pessoa/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = @"Id, Nome, CpfCnpj, DataCadastro, 
            DataNascimento, Imagem, Bio, Observacao, Interesse, Oferecido, Informacao, 
            DocumentoProfissional, Telefone, Celular, Email, Whatsapp, Skype, 
            Ativo, ObservacaoTipoCadastro, Url, PerfilPessoaId")] Pessoa pessoa)
        {
            try
            {
                pessoa.DataCadastro = DateTime.Now;
                _pessoaBll.Salvar(pessoa);

                ExibirMensagem(Mensagens.SALVO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }

                ExibirMensagem(Mensagens.ERRO_AO_ADICIONAR + e.Message, Constants.DANGER);

                throw;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                //log.Error("Error message: " + e.Message + " - " + e.StackTrace);
                ExibirMensagem(Mensagens.ERRO_AO_ADICIONAR, Constants.DANGER);

                ViewBag.PerfilPessoaId = new SelectList(_perfilPessoaBll.Listar(), "Id", "Descricao", pessoa.PerfilPessoaId);
                return View(pessoa);
            }
        }

        // GET: Administrativo/Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            Pessoa pessoa = _pessoaBll.Obter(id);

            if (null == pessoa)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }

            ViewBag.PerfilPessoaId = new SelectList(_perfilPessoaBll.Listar().OrderBy(p => p.Descricao), "Id", "Descricao", pessoa.PerfilPessoaId);

            return View(pessoa);
        }

        // POST: Administrativo/Pessoa/Edit/5
        [HttpPost]
        public ActionResult Edit(int Id, [Bind(Include = @"Id, Nome, CpfCnpj, DataCadastro, 
        DataNascimento, Imagem, Bio, Observacao,Interesse, Oferecido, Informacao, DocumentoProfissional, 
        Telefone, Celular, Email, Whatsapp, Skype, Ativo, ObservacaoTipoCadastro, Url, PerfilPessoaId")] Pessoa pessoa)
        {
            try
            {
                _pessoaBll.Atualizar(pessoa);
                ExibirMensagem(Mensagens.ATUALIZADO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                //log.Error("Error message: " + e.Message + " - " + e.StackTrace);
                ExibirMensagem(Mensagens.ERRO_AO_ATUALIZAR, Constants.DANGER);

                ViewBag.PerfilPessoaId = new SelectList(_perfilPessoaBll.Listar(), "Id", "Descricao", pessoa.PerfilPessoaId);
                return View(pessoa);
            }
        }

        // GET: Administrativo/Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            Pessoa pessoa = _pessoaBll.Obter(id);

            if (null == pessoa)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }

            return View(pessoa);
        }

        // POST: Administrativo/Pessoa/Delete/5
        [HttpPost]
        public ActionResult Delete(int Id, [Bind(Include = @"Id, Nome, CpfCnpj, DataCadastro, 
        DataNascimento, Imagem, Bio, Observacao,Interesse, Oferecido, Informacao, DocumentoProfissional, 
        Telefone, Celular, Email, Whatsapp, Skype, Ativo, ObservacaoTipoCadastro, Url, PerfilPessoaId")] Pessoa pessoa)
        {
            try
            {
                _pessoaBll.Excluir(pessoa);

                ExibirMensagem(Mensagens.EXCLUIDO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                //log.Error("Error message: " + e.Message + " - " + e.StackTrace);
                ExibirMensagem(Mensagens.ERRO_AO_EXCLUIR, Constants.DANGER);
                return View(pessoa);
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
