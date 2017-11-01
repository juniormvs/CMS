using BLL;
using BLL.Interface;
using Model;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Util;

namespace Web.Areas.Administrativo.Controllers
{
    [Authorize]
    public class EquipeController : Controller
    {
        private readonly IPessoaBll _pessoaBll;
        private readonly IEquipeBll _equipeBll;
        private readonly IStatusBll _statusBll;
        private readonly IContatoBll _contatoBll;
        private readonly ITipoContatoBll _tipoContatoBll;

        public EquipeController()
        {
            _equipeBll = new EquipeBll();
            _pessoaBll = new PessoaBll();
            _statusBll = new StatusBll();
            _contatoBll = new ContatoBll();
            _tipoContatoBll = new TipoContatoBll();
        }

        #region CRUD
        // GET: Administrativo/Cliente
        public ActionResult Index()
        {
            return View(_equipeBll.Listar().Include(c => c.Pessoa).Include(c => c.Pessoa.Status).OrderBy(c => c.Pessoa.Nome));
        }

        // GET: Administrativo/Cliente/Details/5
        public ActionResult Details(int id)
        {
            Equipe cliente = _equipeBll.Obter(id);
            if (cliente == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }
            return View(cliente);

        }

        // GET: Administrativo/Cliente/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(_statusBll.Listar(), "Id", "Nome");
            
            VerificarSessao();
            return View();
        }

        // POST: Administrativo/Cliente/Create
        [HttpPost]
        //public ActionResult Create([Bind(Include = "Id, Pessoa, PessoaId, Url")] Equipe cliente)
        public ActionResult Create(FormCollection form)
        {
            try
            {
                Pessoa pessoa = new Pessoa()
                {
                    Nome = form.Get("Pessoa.Nome").Trim(),
                    Bio = form.Get("Pessoa.Bio"),
                    Imagem = form.Get("Pessoa.Imagem"),
                    Observacao = form.Get("Pessoa.Observacao"),
                    StatusId = int.Parse(form.Get("StatusId")),
                    Telefone = form.Get("Pessoa.Telefone"),
                    Celular = form.Get("Pessoa.Celular"),
                    Whatsapp = form.Get("Pessoa.Whatsapp"),
                    Email = form.Get("Pessoa.Email"),

                    DataCadastro = DateTime.Now,
                    Tipo = Constants.EQUIPE
                };

                _pessoaBll.Salvar(pessoa);

                Equipe equipe = new Equipe()
                {
                    PessoaId = pessoa.Id,
                    Cargo = form.Get("Cargo").Trim(),
                    DocumentoProfissional = form.Get("DocumentoProfissional").Trim()
                };

                _equipeBll.Salvar(equipe);

                if (Session[Constants.SESSAO_NOME_ARQUIVO] != null)
                {
                    SalvarImagem(pessoa.Imagem);
                }
                VerificarSessao();

                ExibirMensagem(Mensagens.ADICIONADO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ExibirMensagem(Mensagens.ERRO_AO_ADICIONAR + e, Constants.DANGER);
                ViewBag.StatusId = new SelectList(_statusBll.Listar(), "Id", "Nome", int.Parse(form.Get("StatusId")));
                return View();
            }
        }

        // GET: Administrativo/Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            VerificarSessao();

            Equipe cliente = _equipeBll.Obter(id);
            if (cliente == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(_statusBll.Listar(), "Id", "Nome", cliente.Pessoa.StatusId);

            return View(cliente);
        }

        // POST: Administrativo/Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Equipe equipe = _equipeBll.Obter(int.Parse(collection.Get("Id")));
                Pessoa pessoa = _pessoaBll.Obter(equipe.PessoaId);

                pessoa.Nome = collection.Get("Pessoa.Nome").Trim();
                pessoa.Bio = collection.Get("Pessoa.Bio");
                pessoa.Imagem = collection.Get("Pessoa.Imagem");
                pessoa.Observacao = collection.Get("Pessoa.Observacao");
                pessoa.StatusId = int.Parse(collection.Get("StatusId"));
                pessoa.Telefone = collection.Get("Pessoa.Telefone");
                pessoa.Celular = collection.Get("Pessoa.Celular");
                pessoa.Whatsapp = collection.Get("Pessoa.Whatsapp");
                pessoa.Email = collection.Get("Pessoa.Email");
                pessoa.Tipo = Constants.EQUIPE;

                _pessoaBll.Atualizar(pessoa);

                equipe.Cargo = collection.Get("Cargo").Trim();
                equipe.DocumentoProfissional = collection.Get("DocumentoProfissional").Trim();

                _equipeBll.Atualizar(equipe);

                if (Session[Constants.SESSAO_NOME_ARQUIVO] != null)
                {
                    SalvarImagem(pessoa.Imagem);
                }
                VerificarSessao();

                ExibirMensagem(Mensagens.ATUALIZADO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ExibirMensagem(Mensagens.ERRO_AO_ADICIONAR + e, Constants.DANGER);
                ViewBag.StatusId = new SelectList(_statusBll.Listar(), "Id", "Nome", int.Parse(collection.Get("StatusId")));
                return View();
            }
        }

        // GET: Administrativo/Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            Equipe cliente = _equipeBll.Obter(id);
            if (cliente == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // POST: Administrativo/Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete([Bind(Include = "Id")] Equipe cliente)
        {
            try
            {

                cliente = _equipeBll.Obter(cliente.Id);

                string nomeArquivo = cliente.Pessoa.Imagem;

                _equipeBll.Excluir(cliente);

                DeletarArquivo(nomeArquivo);

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
        #endregion

        #region UPLOAD
        [HttpPost]
        public JsonResult Upload()
        {
            var resultado = new object { };

            if (Request.Files != null)
            {
                try
                {
                    HttpPostedFileBase postedFile = Request.Files[0] as HttpPostedFileBase;
                    string nomeArquivo = Guid.NewGuid().ToString() + Path.GetFileName(postedFile.FileName);
                    string savedFileName = Path.Combine(Server.MapPath(Constants.DIRETORIO_TEMPORARIO), nomeArquivo);
                    postedFile.SaveAs(savedFileName);
                    resultado = new
                    {
                        success = true,
                        message = Mensagens.UPLOAD_IMAGEM_ENVIADA_COM_SUCESSO,
                        nome = nomeArquivo,
                        url = savedFileName
                    };
                    Session[Constants.SESSAO_NOME_ARQUIVO] = nomeArquivo;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    //log.Error("Error message: " + e.Message + " - " + e.StackTrace);
                    resultado = new
                    {
                        success = false,
                        message = Mensagens.UPLOAD_ARQUIVO_INVALIDO
                    };
                }
            }
            else
            {
                resultado = new
                {
                    success = false,
                    message = Mensagens.UPLOAD_ARQUIVO_INVALIDO
                };
            }
            return Json(resultado);
        }

        private void SalvarImagem(string nome)
        {
            string imagem = Session[Constants.SESSAO_NOME_ARQUIVO].ToString();
            string diretorioOrigem = Constants.DIRETORIO_TEMPORARIO;
            string diretorioDestino = Constants.IMG_EQUIPE;

            string ext = Path.GetExtension(diretorioOrigem + imagem);

            string arquivoOrigem = Path.Combine(Server.MapPath(diretorioOrigem), imagem);
            string arquivoDestino = Path.Combine(Server.MapPath(diretorioDestino), nome);

            if (!Directory.Exists(diretorioDestino))
            {
                Directory.CreateDirectory(Server.MapPath(diretorioDestino));
            }

            //sobrepor arquivo de destino, caso exista
            if (System.IO.File.Exists(arquivoDestino))
            {
                System.IO.File.Delete(arquivoDestino);
            }
            System.IO.File.Move(arquivoOrigem, arquivoDestino);

        }

        private void DeletarArquivo(string imagem)
        {
            string arquivo = Path.Combine(Server.MapPath(Constants.IMG_CLIENTE + imagem));
            System.IO.File.Delete(arquivo);
        }

        private void VerificarSessao()
        {
            if (Session[Constants.SESSAO_NOME_ARQUIVO] != null)
            {
                Session.Remove(Constants.SESSAO_NOME_ARQUIVO);
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
