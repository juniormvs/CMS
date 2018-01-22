using BLL;
using BLL.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Util;
using WebApplication.Enum;
using WebApplication.Models;

namespace WebApplication.Areas.Administrativo.Controllers
{
    [Authorize]
    public class ImovelController : Controller
    {

        private readonly IImovelBll _imovelBll;
        private readonly IStatusBll _statusBll;
        private readonly ITipoContratoBll _contratoBll;
        private readonly ITipoImovelBll _tipoImovelBll;
        private readonly IImagemImovelBll _imagemImovelBll;
        private readonly IPessoaBll _pessoaBll;

        private readonly IBairroBll _bairroBll;
        private readonly ICidadeBll _cidadeBll;
        private readonly IEstadoBll _ufBll;

        private readonly IImovelInformacaoBll _infoBll;

        public ImovelController()
        {
            _imovelBll = new ImovelBll();
            _statusBll = new StatusBll();
            _contratoBll = new TipoContratoBll();
            _tipoImovelBll = new TipoImovelBll();
            _imagemImovelBll = new ImagemImovelBll();
            _pessoaBll = new PessoaBll();

            _bairroBll = new BairroBll();
            _cidadeBll = new CidadeBll();
            _ufBll = new EstadoBll();

            _infoBll = new ImovelInformacaoBll();
        }

        private const string CENTRAL_NEGOCIO = @"<p>Para ter mais informa&ccedil;&otilde;es sobre este im&oacute;vel ligue:<br /><br />
                                            <strong>(18) 3217-2771</strong>&nbsp;<strong>CONSULTORIA&nbsp;IMOBILI&Aacute;RIA PRUDENTE</strong><br /><br />
                                            Avenida Brasil, 2219 Jardim Bela D&aacute;ria - Pres. Prudente/SP<br />Creci 28.800-J</p>";

        private const string IMOVEL_BIND = @"Id, Codigo, Descricao, CentralNegocio, PontosFortes, Observacao, Imagem, UrlAmigavel, 
                                            DataCadastro, DataExclusao, UsuarioExclusao, Destaque, Valor, Iptu, Condominio, 
                                            Taxa, ObservacaoValor, Dormitorio, Suite, Banheiro, Garagem, Acomodacoes, Mobiliado, 
                                            EmCondominio, AnoConstrucao, Pavimento, Video, Cep, EnderecoGoogle, Logradouro, 
                                            Numero, Complemento, Zona, Regiao, PontoReferencia, Latitude, Longitude, GerarMapa, 
                                            IncluirNoMapa, AreaTotal, UnMedidaTotal, AreaPrivativa, UnMedidaPrivativa, AreaConstruida, 
                                            UnMedidaConstruida, AreaTerreno, UnMedidaTerreno, TerrenoFrente, UnMedidaTerrenoFrente, 
                                            TerrenoFundo, UnMedidaTerrenoFundo, TerrenoDireita, UnMedidaTerrenoDireita, 
                                            TerrenoEsquerrda, UnMedidaTerrenoEsquerda, NomeCondominio, TipoContratoId, TipoImovelId, 
                                            StatusId, BairroId, CidadeId, CorretorPessoaId, ProprietarioPessoaId, UserId, Bairro, Cidade, Uf,
                                            IdImovelInformacao, Disponibilidade, Exclusividade, Autorizacao, Averbada, Escriturada, 
                                            Financiamento, ComPlaca, LocalChave, Informacao, ImovelId";

        #region CRUD

        // GET: Administrativo/Imovel
        public ActionResult Index()
        {
            return View(_imovelBll.Listar().Include(x => x.Status).OrderByDescending(x => x.Id));
        }

        // GET: Administrativo/Imovel/Details/5
        public ActionResult Details(int id)
        {
            Imovel imovel = _imovelBll.Obter(id);
            if (imovel == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }

            return View(imovel);
        }

        // GET: Administrativo/Imovel/Create
        public ActionResult Create()
        {
            VerificarSessao();

            ViewBag.StatusId = new SelectList(_statusBll.Listar(), "Id", "Nome");
            ViewBag.TipoContratoId = new SelectList(_contratoBll.Listar().OrderBy(x => x.Nome), "Id", "Nome", Constants.ID_VENDA);
            ViewBag.TipoImovelId = new SelectList(_tipoImovelBll.Listar().OrderBy(x => x.Nome), "Id", "Nome");

            ViewBag.EstadoId = new SelectList(_ufBll.Listar().OrderBy(x => x.Nome), "Uf", "Uf", "SP");
            ViewBag.CidadeId = new SelectList(_cidadeBll.Listar("SP"), "Id", "Nome", 3732);
            ViewBag.BairroId = new SelectList(_bairroBll.Listar().OrderBy(x => x.Nome), "Id", "Nome");

            ViewBag.CorretorPessoaId = new SelectList(_pessoaBll.ListarPorPerfil((int)PerfilPessoaEnum.Corretor), "Id","Nome");
            ViewBag.ProprietarioPessoaId = new SelectList(_pessoaBll.ListarPorPerfil((int)PerfilPessoaEnum.Proprietário), "Id","Nome");

            ViewBag.CentralNegocio = CENTRAL_NEGOCIO;

            ViewBag.UnMedidaTotal = new SelectList(PrepararListaMedida(), "Id", "Nome", "m²");
            ViewBag.UnMedidaPrivativa = new SelectList(PrepararListaMedida(), "Id", "Nome", "m²");
            ViewBag.UnMedidaConstruida = new SelectList(PrepararListaMedida(), "Id", "Nome", "m²");
            ViewBag.UnMedidaTerreno = new SelectList(PrepararListaMedida(), "Id", "Nome", "m²");
            ViewBag.UnMedidaTerrenoFrente = new SelectList(PrepararListaMedida(), "Id", "Nome", "m²");
            ViewBag.UnMedidaTerrenoFundo = new SelectList(PrepararListaMedida(), "Id", "Nome", "m²");
            ViewBag.UnMedidaTerrenoDireita = new SelectList(PrepararListaMedida(), "Id", "Nome", "m²");
            ViewBag.UnMedidaTerrenoEsquerda = new SelectList(PrepararListaMedida(), "Id", "Nome", "m²");

            return View();
        }
        
        // POST: Administrativo/Imovel/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = IMOVEL_BIND)] ImovelViewModel imovelViewModel, string command, string imagensMultiUpload)
        {
            System.Diagnostics.Debug.WriteLine(imovelViewModel.ToString());
            try
            {
                if(imovelViewModel.BairroId == 0 && !imovelViewModel.Bairro.Equals(string.Empty))
                {
                    //adicionar bairro
                }

                Imovel imovel = ConverterParaEntity(imovelViewModel);
                ImoveInformacao imoveInformacao = ConverterImovelInformacao(imovelViewModel);

                //TODO ver como pegar o id do usuario logado
                //imovel.UserId = User.Identity.GetUserId();

                await _imovelBll.Salvar(imovel);
                
                if (Session[Constants.SESSAO_NOME_ARQUIVO] != null)
                {
                    SalvarImagem(imovelViewModel.Imagem);
                }

                if (!imagensMultiUpload.Equals(string.Empty))
                {
                    SalvarImagensMultiupload(imagensMultiUpload);
                    PersistirImagensMultiupload(imovel.Id, imagensMultiUpload);
                }

                imoveInformacao.ImovelId = imovel.Id;
                _infoBll.Salvar(imoveInformacao);

                ExibirMensagem(Mensagens.ADICIONADO_COM_SUCESSO, Constants.SUCCESS);

                if (command == null)
                {
                    return RedirectToAction("Index");

                }
                else if (command.Equals(Constants.BTN_SALVAR))
                {
                    return RedirectToAction("Edit", "Imovel", new { id = imovel.Id });
                }
                else if (command.Equals(Constants.BTN_SALVAR_E_ADD_NOVO))
                {
                    return RedirectToAction("Create", "Imovel", null);
                }
                else
                {
                    return RedirectToAction("Index");
                }

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
                PrepararViewBagSelect(imovelViewModel);

                ViewBag.imagensMultiUpload = imagensMultiUpload;

                ExibirMensagem(Mensagens.ERRO_AO_ADICIONAR + e.Message, Constants.DANGER);

                return View(imovelViewModel);
            }

        }

        // GET: Administrativo/Imovel/Edit/5
        public ActionResult Edit(int id)
        {
            VerificarSessao();

            var imovel = _imovelBll.Obter(id);

            if (imovel == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }

            ImovelViewModel imovelViewModel = ConveterParaViewModel(imovel);

            PrepararViewBagSelect(imovelViewModel);

            if (imovel.CentralNegocio == null)
            {
                imovelViewModel.CentralNegocio = CENTRAL_NEGOCIO;
            }

            return View(imovelViewModel);
        }

        // POST: Administrativo/Imovel/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, [Bind(Include = IMOVEL_BIND)] ImovelViewModel imovelViewModel, 
                                        string command, string imagensMultiUpload, string Valor, string ValorCondominio)
        {
            if (command == Constants.BTN_RASCUNHO)
            {
                imovelViewModel.StatusId = 4;
            }
            
            try
            {
                Imovel imovel = ConverterParaEntity(imovelViewModel);
                await _imovelBll.Atualizar(imovel);
                
                if (Session[Constants.SESSAO_NOME_ARQUIVO] != null)
                {
                    SalvarImagem(imovelViewModel.Imagem);
                }

                if (!imagensMultiUpload.Equals(string.Empty))
                {
                    SalvarImagensMultiupload(imagensMultiUpload);
                    PersistirImagensMultiupload(imovelViewModel.Id, imagensMultiUpload);
                }
                
                ExibirMensagem(Mensagens.ADICIONADO_COM_SUCESSO, Constants.SUCCESS);

                if (command == null)
                {
                    return RedirectToAction("Index");
                }
                else if (command.Equals(Constants.BTN_SALVAR))
                {
                    return RedirectToAction("Edit", "Imovel", new { id = imovelViewModel.Id });
                }
                else if (command.Equals(Constants.BTN_SALVAR_E_ADD_NOVO))
                {
                    return RedirectToAction("Create", "Imovel", null);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch(Exception e)
            {
                PrepararViewBagSelect(imovelViewModel);
                ExibirMensagem(Mensagens.ERRO_AO_ATUALIZAR + e.Message, Constants.DANGER);

                return View(imovelViewModel);
            }
        }

        // GET: Administrativo/Imovel/Delete/5
        public ActionResult Delete(int id)
        {
            Imovel imovel = _imovelBll.Obter(id);
            if (imovel == null)
            {
                ExibirMensagem(Mensagens.SELECIONAR_REGISTRO, Constants.WARNING);
                return RedirectToAction("Index");
            }

            return View(imovel);
        }

        // POST: Administrativo/Imovel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var imovel = _imovelBll.Obter(id);

            imovel.UsuarioExclusao = User.Identity.Name;

            try
            {
                _imovelBll.ExcluirLogica(imovel);
                ExibirMensagem(Mensagens.EXCLUIDO_COM_SUCESSO, Constants.SUCCESS);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ExibirMensagem(Mensagens.ERRO_AO_EXCLUIR + e.Message, Constants.DANGER);
                return View(imovel);
            }
        }

        #endregion CRUD

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
            string diretorioDestino = Constants.IMG_IMOVEL;

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

        /// <summary>
        /// Move as imagens realizada no multiupload, do diretorio temporario, para o diretorio definitivo
        /// </summary>
        /// <param name="imagensMultiUpload">lista de nomes de imagens</param>
        private void SalvarImagensMultiupload(string imagensMultiUpload)
        {
            List<string> imagens = imagensMultiUpload.Split(',').ToList();

            string diretorioOrigem = Constants.DIRETORIO_TEMPORARIO;
            string diretorioDestino = Constants.IMG_IMOVEL;

            foreach (var item in imagens)
            {
                string arquivoOrigem = Path.Combine(Server.MapPath(diretorioOrigem), item);
                string arquivoDestino = Path.Combine(Server.MapPath(diretorioDestino), item);

                string arquivoOrigemThumb = Path.Combine(Server.MapPath(diretorioOrigem), item.Replace(Constants.JPG, Constants.THUMB_JPG));
                string arquivoDestinoThumb = Path.Combine(Server.MapPath(diretorioDestino), item.Replace(Constants.JPG, Constants.THUMB_JPG));

                if (!Directory.Exists(diretorioDestino))
                {
                    Directory.CreateDirectory(Server.MapPath(diretorioDestino));
                }

                if (System.IO.File.Exists(arquivoDestino))
                {
                    System.IO.File.Delete(arquivoDestino);
                }

                if (System.IO.File.Exists(arquivoDestinoThumb))
                {
                    System.IO.File.Delete(arquivoDestinoThumb);
                }

                System.IO.File.Move(arquivoOrigem, arquivoDestino);
                System.IO.File.Move(arquivoOrigemThumb, arquivoDestinoThumb);
            }
        }

        private void PersistirImagensMultiupload(int imovelId, string imagensMultiUpload)
        {
            List<string> imagens = imagensMultiUpload.Split(',').ToList();
            List<ImagemImovel> lista = new List<ImagemImovel>();
            int ordem = 0;
            foreach (var item in imagens)
            {
                ImagemImovel imagemImovel = new ImagemImovel
                {
                    ImovelId = imovelId,
                    Imagem = item,
                    Ordem = ordem
                };

                lista.Add(imagemImovel);

                ordem++;
            }

            _imagemImovelBll.Salvar(lista);
        }

        private void DeletarArquivo(string imagem)
        {
            string arquivo = Path.Combine(Server.MapPath(Constants.IMG_IMOVEL + imagem));
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

        #region Convert
        private Imovel ConverterParaEntity(ImovelViewModel imovelViewModel)
        {
            Bairro bairro =_bairroBll.ObterPorNome(imovelViewModel.Bairro);

            if(null == bairro)
            {
                Bairro novoBairro = new Bairro
                {
                    Nome = imovelViewModel.Bairro,
                    UrlAmigavel = Texto.FormatarParaURLAmigavel(imovelViewModel.Bairro)
                };
                _bairroBll.Salvar(novoBairro);
                bairro = novoBairro;
            }
            
            Cidade cidade = _cidadeBll.ObterPorNome(imovelViewModel.Cidade);

            Imovel imovel = new Imovel
            {
                Id = imovelViewModel.Id,
                Codigo = imovelViewModel.Codigo,
                Descricao = imovelViewModel.Descricao,
                CentralNegocio = imovelViewModel.CentralNegocio,
                PontosFortes = imovelViewModel.PontosFortes,
                Observacao = imovelViewModel.Observacao,
                Imagem = imovelViewModel.Imagem,
                UrlAmigavel = imovelViewModel.UrlAmigavel,
                DataCadastro = Convert.ToDateTime(imovelViewModel.DataCadastro),
                DataExclusao = Convert.ToDateTime(imovelViewModel.DataExclusao),
                UsuarioExclusao = imovelViewModel.UsuarioExclusao,
                Destaque = imovelViewModel.Destaque,
                Valor = Convert.ToDecimal(imovelViewModel.Valor),
                Iptu = Convert.ToDecimal(imovelViewModel.Iptu),
                Condominio = Convert.ToDecimal(imovelViewModel.Condominio),
                Taxa = Convert.ToDecimal(imovelViewModel.Taxa),
                ObservacaoValor = imovelViewModel.ObservacaoValor,
                Dormitorio = imovelViewModel.Dormitorio,
                Suite = imovelViewModel.Suite,
                Banheiro = imovelViewModel.Banheiro,
                Garagem = imovelViewModel.Garagem,
                Acomodacoes = imovelViewModel.Acomodacoes,
                Mobiliado = imovelViewModel.Mobiliado,
                EmCondominio = imovelViewModel.EmCondominio,
                AnoConstrucao = imovelViewModel.AnoConstrucao,
                Pavimento = imovelViewModel.Pavimento,
                Video = imovelViewModel.Video,
                Cep = imovelViewModel.Cep,
                EnderecoGoogle = imovelViewModel.EnderecoGoogle,
                Logradouro = imovelViewModel.Logradouro,
                Numero = imovelViewModel.Numero,
                Complemento = imovelViewModel.Complemento,
                Zona = imovelViewModel.Zona,
                Regiao = imovelViewModel.Regiao,
                PontoReferencia = imovelViewModel.PontoReferencia,
                Latitude = imovelViewModel.Latitude,
                Longitude = imovelViewModel.Longitude,
                GerarMapa = imovelViewModel.GerarMapa,
                IncluirNoMapa = imovelViewModel.IncluirNoMapa,
                AreaTotal = Convert.ToDouble(imovelViewModel.AreaTotal),
                UnMedidaTotal = imovelViewModel.UnMedidaTotal,
                AreaPrivativa = Convert.ToDouble(imovelViewModel.AreaPrivativa),
                UnMedidaPrivativa = imovelViewModel.UnMedidaPrivativa,
                AreaConstruida = Convert.ToDouble(imovelViewModel.AreaConstruida),
                UnMedidaConstruida = imovelViewModel.UnMedidaConstruida,
                AreaTerreno = Convert.ToDouble(imovelViewModel.AreaTerreno),
                UnMedidaTerreno = imovelViewModel.UnMedidaTerreno,
                TerrenoFrente = Convert.ToDouble(imovelViewModel.TerrenoFrente),
                UnMedidaTerrenoFrente = imovelViewModel.UnMedidaTerrenoFrente,
                TerrenoFundo = Convert.ToDouble(imovelViewModel.TerrenoFundo),
                UnMedidaTerrenoFundo = imovelViewModel.UnMedidaTerrenoFundo,
                TerrenoDireita = Convert.ToDouble(imovelViewModel.TerrenoDireita),
                UnMedidaTerrenoDireita = imovelViewModel.UnMedidaTerrenoDireita,
                TerrenoEsquerrda = Convert.ToDouble(imovelViewModel.TerrenoEsquerrda),
                UnMedidaTerrenoEsquerda = imovelViewModel.UnMedidaTerrenoEsquerda,
                TipoContratoId = imovelViewModel.TipoContratoId,
                TipoImovelId = imovelViewModel.TipoImovelId,
                StatusId = imovelViewModel.StatusId,
                BairroId = bairro.Id,
                CidadeId = cidade.Id,
                CorretorPessoaId = imovelViewModel.CorretorPessoaId,
                ProprietarioPessoaId = imovelViewModel.ProprietarioPessoaId,
                UserId = imovelViewModel.UserId,
            };

            return imovel;
        }

        private ImovelViewModel ConveterParaViewModel(Imovel imovel)
        {
            ImovelViewModel imovelViewModel = new ImovelViewModel
            {
                //TODO realizar a conversao
                Id = imovel.Id,
                Codigo = imovel.Codigo,
                Descricao = imovel.Descricao,
                CentralNegocio = imovel.CentralNegocio,
                PontosFortes = imovel.PontosFortes,
                Observacao = imovel.Observacao,
                Imagem = imovel.Imagem,
                UrlAmigavel = imovel.UrlAmigavel,
                DataCadastro = imovel.DataCadastro.ToString(),
                DataExclusao = imovel.DataExclusao.ToString(),
                UsuarioExclusao = imovel.UsuarioExclusao,
                Destaque = imovel.Destaque,
                Valor = imovel.Valor.ToString(),
                Iptu = imovel.Iptu.ToString(),
                Condominio = imovel.Condominio.ToString(),
                Taxa = imovel.Taxa.ToString(),
                ObservacaoValor = imovel.ObservacaoValor,
                Dormitorio = imovel.Dormitorio,
                Suite = imovel.Suite,
                Banheiro = imovel.Banheiro,
                Garagem = imovel.Garagem,
                Acomodacoes = imovel.Acomodacoes,
                Mobiliado = imovel.Mobiliado,
                EmCondominio = imovel.EmCondominio,
                AnoConstrucao = imovel.AnoConstrucao,
                Pavimento = imovel.Pavimento,
                Video = imovel.Video,
                Cep = imovel.Cep,
                EnderecoGoogle = imovel.EnderecoGoogle,
                Logradouro = imovel.Logradouro,
                Numero = imovel.Numero,
                Complemento = imovel.Complemento,
                Zona = imovel.Zona,
                Regiao = imovel.Regiao,
                PontoReferencia = imovel.PontoReferencia,
                Latitude = imovel.Latitude,
                Longitude = imovel.Longitude,
                GerarMapa = imovel.GerarMapa,
                IncluirNoMapa = imovel.IncluirNoMapa,
                AreaTotal = imovel.AreaTotal.ToString(),
                UnMedidaTotal = imovel.UnMedidaTotal,
                AreaPrivativa = imovel.AreaPrivativa.ToString(),
                UnMedidaPrivativa = imovel.UnMedidaPrivativa,
                AreaConstruida = imovel.AreaConstruida.ToString(),
                UnMedidaConstruida = imovel.UnMedidaConstruida,
                AreaTerreno = imovel.AreaTerreno.ToString(),
                UnMedidaTerreno = imovel.UnMedidaTerreno,
                TerrenoFrente = imovel.TerrenoFrente.ToString(),
                UnMedidaTerrenoFrente = imovel.UnMedidaTerrenoFrente,
                TerrenoFundo = imovel.TerrenoFundo.ToString(),
                UnMedidaTerrenoFundo = imovel.UnMedidaTerrenoFundo,
                TerrenoDireita = imovel.TerrenoDireita.ToString(),
                UnMedidaTerrenoDireita = imovel.UnMedidaTerrenoDireita,
                TerrenoEsquerrda = imovel.TerrenoEsquerrda.ToString(),
                UnMedidaTerrenoEsquerda = imovel.UnMedidaTerrenoEsquerda,
                TipoContratoId = imovel.TipoContratoId,
                TipoImovelId = imovel.TipoImovelId,
                StatusId = imovel.StatusId,
                BairroId = imovel.BairroId,
                CidadeId = imovel.CidadeId,
                CorretorPessoaId = imovel.CorretorPessoaId,
                ProprietarioPessoaId = imovel.ProprietarioPessoaId,
                UserId = imovel.UserId
            };
            return imovelViewModel;
        }

        public ImoveInformacao ConverterImovelInformacao(ImovelViewModel imovelViewModel)
        {
            ImoveInformacao info = new ImoveInformacao
            {
                Autorizacao = imovelViewModel.Autorizacao,
                Averbada = imovelViewModel.Averbada,
                ComPlaca = imovelViewModel.ComPlaca,
                DataCadastro = DateTime.Now,
                Disponibilidade = imovelViewModel.Disponibilidade,
                Escriturada = imovelViewModel.Escriturada,
                Exclusividade = imovelViewModel.Exclusividade,
                Financiamento = imovelViewModel.Financiamento,
                Informacao = imovelViewModel.Informacao,
                LocalChave = imovelViewModel.LocalChave
            };

            return info;
        }

        public ImovelViewModel ConverterInformacaoEmImovel(ImoveInformacao info, ImovelViewModel vm)
        {
            vm.Autorizacao = info.Autorizacao;
            vm.Averbada = info.Averbada;
            vm.ComPlaca = info.ComPlaca;
            vm.DataCadastro = info.DataCadastro.ToString();
            vm.Disponibilidade = info.Disponibilidade;
            vm.Escriturada = info.Escriturada;
            vm.Exclusividade = info.Exclusividade;
            vm.Financiamento = info.Financiamento;
            vm.Informacao = info.Informacao;
            vm.LocalChave = info.LocalChave;

            return vm;
        }

        private void MontarUrlSeo(Imovel imovel)
        {
            //TODO criar regra para montar url amigavel do imovel
            // https://www.zapimoveis.com.br/lancamento/apartamento+venda+jd-guaio+suzano+sp+parque-soneto+mrv-engenharia-s-a+42m2/ID-12844/?oti=1
            // tipo imovel / tipo contrato / bairro / cidade / id
            string tipo = Texto.FormatarParaURLAmigavel(imovel.TipoImovel.Nome);
            string finalidade = "-" + imovel.TipoContrato.UrlAmigavel;
            string bairro = "-" + imovel.Bairro.UrlAmigavel;
            string cidade = "-" + Texto.FormatarParaURLAmigavel(imovel.Cidade.Nome);
            string uf = "-" + imovel.Cidade.Uf;
            string metragem = "-" + imovel.AreaTotal.ToString() + "m2";

            imovel.UrlAmigavel = tipo + finalidade + bairro + cidade + uf + metragem;
        }
        #endregion Convert

        private void PrepararViewBagSelect(ImovelViewModel imovelViewModel)
        {
            ViewBag.StatusId = new SelectList(_statusBll.Listar(), "Id", "Nome", imovelViewModel.StatusId);
            ViewBag.TipoContratoId = new SelectList(_contratoBll.Listar().OrderBy(x => x.Nome), "Id", "Nome", imovelViewModel.TipoContratoId);
            ViewBag.TipoImovelId = new SelectList(_tipoImovelBll.Listar().OrderBy(x => x.Nome), "Id", "Nome", imovelViewModel.TipoImovelId);
            ViewBag.EstadoId = new SelectList(_ufBll.Listar().OrderBy(x => x.Nome), "Uf", "Uf", imovelViewModel.Uf);
            ViewBag.CidadeId = new SelectList(_cidadeBll.Listar(imovelViewModel.Uf), "Id", "Nome", imovelViewModel.CidadeId);
            ViewBag.BairroId = new SelectList(_bairroBll.Listar().OrderBy(x => x.Nome), "Id", "Nome", imovelViewModel.BairroId);
            ViewBag.CorretorPessoaId = new SelectList(_pessoaBll.ListarPorPerfil((int)PerfilPessoaEnum.Corretor), "Id", "Nome", imovelViewModel.CorretorPessoaId);
            ViewBag.ProprietarioPessoaId = new SelectList(_pessoaBll.ListarPorPerfil((int)PerfilPessoaEnum.Proprietário), "Id", "Nome", imovelViewModel.ProprietarioPessoaId);
            ViewBag.UnMedidaTotal = new SelectList(PrepararListaMedida(), "Id", "Nome", imovelViewModel.UnMedidaTotal);
            ViewBag.UnMedidaPrivativa = new SelectList(PrepararListaMedida(), "Id", "Nome", imovelViewModel.UnMedidaPrivativa);
            ViewBag.UnMedidaConstruida = new SelectList(PrepararListaMedida(), "Id", "Nome", imovelViewModel.UnMedidaConstruida);
            ViewBag.UnMedidaTerreno = new SelectList(PrepararListaMedida(), "Id", "Nome", imovelViewModel.UnMedidaTerreno);
            ViewBag.UnMedidaTerrenoFrente = new SelectList(PrepararListaMedida(), "Id", "Nome", imovelViewModel.UnMedidaTerrenoFrente);
            ViewBag.UnMedidaTerrenoFundo = new SelectList(PrepararListaMedida(), "Id", "Nome", imovelViewModel.UnMedidaTerrenoFundo);
            ViewBag.UnMedidaTerrenoDireita = new SelectList(PrepararListaMedida(), "Id", "Nome", imovelViewModel.UnMedidaTerrenoDireita);
            ViewBag.UnMedidaTerrenoEsquerda = new SelectList(PrepararListaMedida(), "Id", "Nome", imovelViewModel.UnMedidaTerrenoEsquerda);

        }

        private dynamic PrepararListaMedida()
        {
            List<string> listaDeMedidas = new List<string>
            {
                "m²",
                "Metros",
                "Km²",
                "Km",
                "Hectares",
                "Acres",
                "Alqueires",
                "Alqueires Paulista",
                "Alqueires Mineiro",
                "Alqueires Baiano",
                "Alqueires do Norte"
            };

            List<Medida> listaMedida = new List<Medida>();
            foreach (string s in listaDeMedidas)
            {
                Medida m = new Medida
                {
                    Id = s,
                    Nome = s
                };

                listaMedida.Add(m);
            }
            
            return listaMedida;
        }

        private void ExibirMensagem(string mensagem, string tipo)
        {
            TempData[Constants.MENSAGEM] = mensagem;
            TempData[Constants.CSS_CLASS] = tipo;
        }
    }
}
