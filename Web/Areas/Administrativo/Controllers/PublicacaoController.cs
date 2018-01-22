using BLL;
using BLL.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Util;

namespace Web.Areas.Administrativo.Controllers
{
    
    public class PublicacaoController : Controller
    {
        private readonly IPublicacaoBll _publicacaoBll;
        private readonly ICategoriaPublicacaoBll _categoriaPublicacaoBll;
        private readonly IStatusBll _statusBll;
        private readonly IImagemPublicacaoBll _imagemBll;
        private readonly IPublicacaoPorCategoriaBll _publicacaoPorCategoriaBll;

        public PublicacaoController()
        {
            _publicacaoBll = new PublicacaoBll();
            _categoriaPublicacaoBll = new CategoriaPublicacaoBll();
            _statusBll = new StatusBll();
            _imagemBll = new ImagemPublicacaoBll();
            _publicacaoPorCategoriaBll = new PublicacaoPorCategoriaBll();
        }

        #region CRUD

        // GET: Administrativo/Publicacao
        public ActionResult Index()
        {
            List<Publicacao> lista = _publicacaoBll.Listar().Include(p => p.Status).Include(p => p.PublicacaoPorCategoria).OrderByDescending(p => p.DataPublicacao).ToList();

            return View(lista);
        }

        // GET: Administrativo/Publicacao/Details/5
        public ActionResult Details(int id)
        {
            Publicacao publicacao = _publicacaoBll.Obter(id);
            if (publicacao == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }
            return View(publicacao);
        }

        // GET: Administrativo/Publicacao/Create
        public ActionResult Create()
        {
            ViewBag.StatusId = new SelectList(_statusBll.ListarStatusPublicacao(), "Id", "Nome");
            ViewBag.Categorias = new MultiSelectList(_categoriaPublicacaoBll.ListarTodos(), "Id", "Nome");
            ViewBag.BtnSalvar = Constants.BTN_RASCUNHO;
            return View();
        }

        // POST: Administrativo/Publicacao/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = @"Titulo, Resumo, Texto, Imagem, 
                            DataPublicacao, ExibirComoPopup, PostarNoFacebook")] Publicacao publicacao,
                            List<int> categorias, string command)
        {
            publicacao.UrlAmigavel = Texto.FormatarParaURLAmigavel(publicacao.Titulo);
            
            publicacao.PublicacaoPorCategoria = ResolverCategorias(categorias, null);

            publicacao.DataPublicacao = publicacao.DataPublicacao == null ? DateTime.Now : publicacao.DataPublicacao;

            try
            {
                if (command.Equals(Constants.BTN_PUBLICAR))
                {
                    publicacao.StatusId = Constants.STATUS_PUBLICADO_ID;
                }
                else
                {
                    publicacao.StatusId = Constants.STATUS_RASCUNHO_ID;
                }

                _publicacaoBll.Salvar(publicacao);

                if (Session[Constants.SESSAO_NOME_ARQUIVO] != null)
                {
                    SalvarImagem(publicacao.Imagem);
                }

                string msg = publicacao.StatusId.Equals(Constants.STATUS_RASCUNHO_ID) ? Mensagens.RASCUNHO_SALVO_SUCESSO : Mensagens.PUBLICADO_COM_SUCESSO;
                ExibirMensagem(msg, Constants.SUCCESS);

                return RedirectToAction("Edit","Publicacao", new { id = publicacao.Id});
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
                ExibirMensagem(e.Message, Constants.DANGER);

                ViewBag.StatusId = new SelectList(_statusBll.ListarStatusPublicacao(), "Id", "Nome");
                ViewBag.Categorias = new MultiSelectList(_categoriaPublicacaoBll.ListarTodos(), "Id", "Nome", categorias);
                return View(publicacao);
            }
        }

        private ICollection<PublicacaoPorCategoria> ResolverCategorias(List<int> categorias, int? publicacaoId)
        {
            if (categorias == null)
            {
                categorias = new List<int>();
                categorias.Add(Constants.ID_CATEGORIA_NOTICIA);
            }

            List<PublicacaoPorCategoria> listaCategorias = new List<PublicacaoPorCategoria>();

            foreach (var idCategoria in categorias)
            {
                PublicacaoPorCategoria publicacaoPorCategoria = new PublicacaoPorCategoria()
                {
                    CategoriaId = idCategoria,
                    PublicacaoId = publicacaoId.GetValueOrDefault()
                };
                listaCategorias.Add(publicacaoPorCategoria);
            }

            return listaCategorias;
        }

        // GET: Administrativo/Publicacao/Edit/5
        public ActionResult Edit(int id)
        {
            Publicacao publicacao = _publicacaoBll.Obter(id);
            if (publicacao == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(_statusBll.ListarStatusPublicacao(), "Id", "Nome", publicacao.StatusId);
            ViewBag.Categorias = new MultiSelectList(_categoriaPublicacaoBll.ListarTodos(), "Id", "Nome");
            ViewBag.CategoriasPublicacao = publicacao.PublicacaoPorCategoria;
            System.Diagnostics.Trace.WriteLine("CATEGORIAS : " + publicacao.PublicacaoPorCategoria);

            ViewBag.BtnSalvar = Constants.BTN_SALVAR;

            return View(publicacao);
        }

        // POST: Administrativo/Publicacao/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = @"Id, Titulo, Resumo, Texto, Imagem, 
                            DataPublicacao, ExibirComoPopup, PostarNoFacebook, StatusId, Status")] Publicacao publicacao,
                            List<int> categorias, string command)
        {
            publicacao.UrlAmigavel = Texto.FormatarParaURLAmigavel(publicacao.Titulo);
            publicacao.DataAtualizacao = DateTime.Now;

            if (command.Equals(Constants.BTN_PUBLICAR))
            {
                publicacao.StatusId = Constants.STATUS_PUBLICADO_ID;
            }
            
            try
            {
                _publicacaoPorCategoriaBll.ExcluirPorPublicacao(publicacao.Id);
                
                _publicacaoBll.Atualizar(publicacao);

                List<PublicacaoPorCategoria> publicacaoPorCategoria = ResolverCategorias(categorias, publicacao.Id).ToList();
                _publicacaoPorCategoriaBll.Salvar(publicacaoPorCategoria);

                if (Session[Constants.SESSAO_NOME_ARQUIVO] != null)
                {
                    SalvarImagem(publicacao.Imagem);
                }

                string msg = publicacao.StatusId.Equals(Constants.STATUS_RASCUNHO_ID) ? Mensagens.RASCUNHO_SALVO_SUCESSO : Mensagens.PUBLICADO_COM_SUCESSO;
                ExibirMensagem(msg, Constants.SUCCESS);

                return RedirectToAction("Edit", "Publicacao", new { id = publicacao.Id });
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
                System.Diagnostics.Debug.WriteLine(e);
                //log.Error("Error message: " + e.Message + " - " + e.StackTrace);
                ExibirMensagem(Mensagens.ERRO_AO_ATUALIZAR, Constants.DANGER);

                ViewBag.StatusId = new SelectList(_statusBll.ListarStatusPublicacao(), "Id", "Nome", publicacao.StatusId);
                ViewBag.Categorias = new MultiSelectList(_categoriaPublicacaoBll.ListarTodos(), "Id", "Nome");
                ViewBag.PublicacaoPorCategoria = publicacao.PublicacaoPorCategoria;

                ViewBag.BtnSalvar = Constants.BTN_SALVAR;

                return View(publicacao);
            }
        }

        // GET: Administrativo/Publicacao/Delete/5
        public ActionResult Delete(int id)
        {
            Publicacao publicacao = _publicacaoBll.Obter(id);
            if (publicacao == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }
            return View(publicacao);
        }

        // POST: Administrativo/Publicacao/Delete/5
        [HttpPost]
        public ActionResult Delete(Publicacao publicacao)
        {
            try
            {
                publicacao = _publicacaoBll.Obter(publicacao.Id);

                //foreach (var item in publicacao.CategoriaPublicacao)
                //{
                //    _categoriaPublicacaoBll.Excluir(item);
                //}

                _publicacaoBll.Excluir(publicacao);

                ExibirMensagem(Mensagens.EXCLUIDO_COM_SUCESSO, Constants.SUCCESS);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
                System.Diagnostics.Debug.WriteLine(e.Message);
                //log.Error("Error message: " + e.Message + " - " + e.StackTrace);
                ExibirMensagem(Mensagens.ERRO_AO_EXCLUIR, Constants.DANGER);
                return View(publicacao);
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
                    resultado = new
                    {
                        success = false,
                        message = Mensagens.UPLOAD_ARQUIVO_INVALIDO + " - " + e.Message
                    };
                    //Log.Error("Erro upload blog: " + e.Message + " - " + e.StackTrace + " - " + e.InnerException);
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
            string diretorioDestino = Constants.IMG_PUBLICACAO;

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
            string arquivo = Path.Combine(Server.MapPath(Constants.IMG_PUBLICACAO + imagem));
            System.IO.File.Delete(arquivo);
        }

        #endregion UPLOAD

        private void ExibirMensagem(string mensagem, string tipo)
        {
            TempData[Constants.MENSAGEM] = mensagem;
            TempData[Constants.CSS_CLASS] = tipo;
        }
    }
}
