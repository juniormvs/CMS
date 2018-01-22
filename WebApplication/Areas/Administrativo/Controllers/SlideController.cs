using BLL;
using BLL.Interface;
using Model;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Util;

namespace WebApplication.Areas.Administrativo.Controllers
{

    public class SlideController : Controller
    {
        private readonly ISlideBll _slideBll;

        public SlideController()
        {
            _slideBll = new SlideBll();
        }

        #region CRUD
        // GET: Administrativo/Slide
        public ActionResult Index()
        {
            return View(_slideBll.Listar());
        }

        // GET: Administrativo/Slide/Details/5
        public ActionResult Details(int id)
        {
            Slide slide = _slideBll.Obter(id);

            if (slide == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }

            return View(slide);
        }

        // GET: Administrativo/Slide/Create
        public ActionResult Create()
        {
            VerificarSessao();
            return View();
        }

        // POST: Administrativo/Slide/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Imagem,Titulo,Subtitulo,Url")] Slide slide)
        {
            try
            {
                _slideBll.Salvar(slide);

                if (Session[Constants.SESSAO_NOME_ARQUIVO] != null)
                {
                    SalvarImagem(slide.Imagem);
                }

                ExibirMensagem(Mensagens.SALVO_COM_SUCESSO, Constants.SUCCESS);
                VerificarSessao();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                //log.Error("Error message: " + e.Message + " - " + e.StackTrace);
                ExibirMensagem(Mensagens.ERRO_AO_ADICIONAR, Constants.DANGER);
                return View(slide);
            }
        }

        // GET: Administrativo/Slide/Edit/5
        public ActionResult Edit(int id)
        {
            Slide slide = _slideBll.Obter(id);
            if (slide == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }

            VerificarSessao();

            return View(slide);
        }

        // POST: Administrativo/Slide/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Imagem,Titulo,Subtitulo,Url")] Slide slide)
        {
            try
            {
                _slideBll.Atualizar(slide);
                if (Session[Constants.SESSAO_NOME_ARQUIVO] != null)
                {
                    SalvarImagem(slide.Imagem);
                }
                ExibirMensagem(Mensagens.ATUALIZADO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                //log.Error("Error message: " + e.Message + " - " + e.StackTrace);
                ExibirMensagem(Mensagens.ERRO_AO_ATUALIZAR, Constants.DANGER);
                return View(slide);
            }
        }

        // GET: Administrativo/Slide/Delete/5
        public ActionResult Delete(int id)
        {
            Slide slide = _slideBll.Obter(id);
            if (slide == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }

            return View(slide);
        }

        // POST: Administrativo/Slide/Delete/5
        [HttpPost]
        public ActionResult Delete([Bind(Include = "Id,Imagem,Titulo,Subtitulo,Url")] Slide slide)
        {
            try
            {
                slide = _slideBll.Obter(slide.Id);

                string nomeArquivo = slide.Imagem;

                _slideBll.Excluir(slide);

                DeletarArquivo(nomeArquivo);

                ExibirMensagem(Mensagens.EXCLUIDO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                //log.Error("Error message: " + e.Message + " - " + e.StackTrace);
                ExibirMensagem(Mensagens.ERRO_AO_EXCLUIR, Constants.DANGER);
                return View(slide);
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
                    //log.Error("Error message: " + e.Message + " - " + e.StackTrace);
                    resultado = new
                    {
                        success = false,
                        message = Mensagens.UPLOAD_ARQUIVO_INVALIDO + e.Message
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
            string diretorioDestino = Constants.IMG_SLIDE;

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
            string arquivo = Path.Combine(Server.MapPath(Constants.IMG_SLIDE + imagem));
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
