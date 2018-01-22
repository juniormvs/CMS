using BLL;
using BLL.Interface;
using Model;
using System;
using System.Data.Entity.Validation;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Util;

namespace WebApplication.Areas.Administrativo.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IEmpresaBll _empresaBll;

        public EmpresaController()
        {
            _empresaBll = new EmpresaBll();
        }

        // GET: Administrativo/Empresa
        public ActionResult Index()
        {
            return RedirectToAction("Details", "Empresa", new { id = 1 });
        }

        // GET: Administrativo/Empresa/Details/5
        public ActionResult Details(int id)
        {
            id = 1; // força id sempre 1
            return View(_empresaBll.Obter(id));
        }

        // GET: Administrativo/Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrativo/Empresa/Create
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

        // GET: Administrativo/Empresa/Edit/5
        public ActionResult Edit(int id)
        {
            id = 1;
            
            VerificarSessao();

            return View(_empresaBll.Obter(id));
        }

        [HttpGet]
        public ActionResult ObterSkin()
        {
            Empresa empresa = _empresaBll.Obter(1);
            return Content(empresa.TemaPainel);
        }

        [HttpPost]
        public string AtualizarSkin(string skin)
        {
            Empresa empresa = _empresaBll.Obter(1);
            empresa.TemaPainel = skin;

            try
            {
                _empresaBll.AtualizarSkin(empresa);
            }
            catch (Exception e)
            {
                return "ERROR - " + e.Message;
            }

            return "OK";
        }

        // POST: Administrativo/Empresa/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = @"Id, Nome, Descricao,
            Resumo, Endereco, Telefone, Whatsapp, Email, Imagem, Logo, TemaPainel")] Empresa empresa, string novaImagem)
        {
            try
            {
                await _empresaBll.Atualizar(empresa);

                if (!string.IsNullOrEmpty(novaImagem))
                {
                    SalvarImagem(empresa.Imagem);
                }

                ExibirMensagem(Mensagens.ATUALIZADO_COM_SUCESSO, Constants.SUCCESS);
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
                throw;
            }
            catch (Exception e)
            {
                ExibirMensagem(Mensagens.ERRO_AO_ATUALIZAR + e, Constants.DANGER);
                return View(empresa);
            }
        }
        
        // GET: Administrativo/Empresa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administrativo/Empresa/Delete/5
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
                    string nomeArquivo = "Imobiliaria Prudente.jpg";//Guid.NewGuid().ToString() + Path.GetFileName(postedFile.FileName);
                    string savedFileName = Path.Combine(Server.MapPath(Constants.DIRETORIO_TEMPORARIO), nomeArquivo);
                    postedFile.SaveAs(savedFileName);
                    resultado = new
                    {
                        success = true,
                        message = Mensagens.UPLOAD_IMAGEM_ENVIADA_COM_SUCESSO,
                        nome = nomeArquivo,
                        url = savedFileName
                    };
                    //Session[Constants.SESSAO_NOME_ARQUIVO] = nomeArquivo;
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
            string imagem = nome;
            string diretorioOrigem = Constants.DIRETORIO_TEMPORARIO;
            string diretorioDestino = Constants.IMG_EMPRESA;

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
            string arquivo = Path.Combine(Server.MapPath(Constants.IMG_EMPRESA + imagem));
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

    }
}
