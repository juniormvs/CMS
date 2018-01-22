using BLL;
using BLL.Interface;
using Model;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Util;

namespace Web.Areas.Administrativo.Controllers
{
    
    public class ServicoController : Controller
    {
        private readonly IServicoBll _servicoBll;

        public ServicoController()
        {
            _servicoBll = new ServicoBll();
        }

        // GET: Administrativo/Servico
        public ActionResult Index()
        {
            return View(_servicoBll.ListarTodosPorTipo(Constants.ID_TIPO_SERVICO).OrderBy(s => s.Nome));
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
            VerificarSessao();
            return View();
        }

        // POST: Administrativo/Servico/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id, Nome, Resumo, Descricao, Icone, Imagem, UrlAmigavel, Ativo")] Servico servico)
        {
            servico.TipoId = Constants.ID_TIPO_SERVICO;
            servico.UrlAmigavel = Texto.FormatarParaURLAmigavel(servico.Nome);
            try
            {
                _servicoBll.Salvar(servico);

                if(Session[Constants.SESSAO_NOME_ARQUIVO] != null)
                {
                    SalvarImagem(servico.Imagem);
                }

                ExibirMensagem(Mensagens.ADICIONADO_COM_SUCESSO, Constants.SUCCESS);
                VerificarSessao();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ExibirMensagem(Mensagens.ERRO_AO_ADICIONAR + e.Message, Constants.DANGER);
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
            VerificarSessao();
            return View(servico);
        }

        // POST: Administrativo/Servico/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, Nome, Resumo, Descricao, Icone, Imagem, UrlAmigavel, Ativo")] Servico servico)
        {
            servico.TipoId = Constants.ID_TIPO_SERVICO;
            servico.UrlAmigavel = Texto.FormatarParaURLAmigavel(servico.Nome);
            try
            {
                _servicoBll.Atualizar(servico);

                if (Session[Constants.SESSAO_NOME_ARQUIVO] != null)
                {
                    SalvarImagem(servico.Imagem);
                }

                VerificarSessao();
                ExibirMensagem(Mensagens.ATUALIZADO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ExibirMensagem(Mensagens.ERRO_AO_ADICIONAR + e.Message, Constants.DANGER);
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
                string nomeArquivo = servico.Imagem;

                _servicoBll.Excluir(servico);

                DeletarArquivo(nomeArquivo);

                ExibirMensagem(Mensagens.EXCLUIDO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                ExibirMensagem(Mensagens.ERRO_AO_EXCLUIR, Constants.DANGER);
                return View(servico);
            }
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
            string diretorioDestino = Constants.IMG_SERVICO;

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

        private void ExibirMensagem(string mensagem, string tipo)
        {
            TempData[Constants.MENSAGEM] = mensagem;
            TempData[Constants.CSS_CLASS] = tipo;
        }
    }
}
