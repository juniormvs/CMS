using BLL;
using BLL.Interface;
using Model;
using Newtonsoft.Json;
using System;
using System.Data.Entity.Validation;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Util;

namespace Web.Areas.Administrativo.Controllers
{
    [Authorize]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaBll _empresaBll;
        private readonly IPessoaBll _pessoaBll;
        private readonly IStatusBll _statusBll;

        public EmpresaController()
        {
            _empresaBll = new EmpresaBll();
            _pessoaBll = new PessoaBll();
            _statusBll = new StatusBll();
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

        [HttpPost]
        public string AtualizarSkin(string skin)
        {
            Empresa empresa = _empresaBll.Obter(1);
            empresa.TemaPainel = skin;

            try
            {
                _empresaBll.Atualizar(empresa);
            }
            catch (Exception e)
            {
                return "ERROR - " + e.Message;
            }

            return "OK";
        }

        // POST: Administrativo/Empresa/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = @"Id, Email, Telefone, Endereco, TemaPainel,
            Logo, Resumo, Pessoa, PessoaId")] Empresa empresa)
        {
            if (empresa.Endereco != null)
            {
                await GetLatLong(empresa);
            }

            Pessoa pessoa = _pessoaBll.Obter(empresa.PessoaId);

            pessoa.Nome = empresa.Pessoa.Nome;
            pessoa.Bio = empresa.Pessoa.Bio;
            pessoa.Imagem = empresa.Pessoa.Imagem;
            pessoa.Observacao = empresa.Pessoa.Observacao;
            pessoa.StatusId = Constants.STATUS_ATIVO_ID;
            pessoa.Tipo = Constants.EMPRESA;
            
            try
            {
                _pessoaBll.Atualizar(pessoa);
                empresa.Pessoa = null;
                _empresaBll.Atualizar(empresa);

                if (Session[Constants.SESSAO_NOME_ARQUIVO] != null)
                {
                    SalvarImagem(pessoa.Imagem);
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
        
        private async Task GetLatLong(Empresa empresa)
        {
            HttpClient client = new HttpClient();
        
            string url = "https://maps.googleapis.com/maps/api/geocode/json?";
            string address = "address=" + empresa.Endereco.Replace(" ","+");
            string key = "&key=AIzaSyBU7wcTnef3GwcAzGTGCrX-1uEwpMRRoM4";

            HttpResponseMessage response = await client.GetAsync(url + address + key);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            JsonSerializer json = new JsonSerializer();

            dynamic dynObj = JsonConvert.DeserializeObject(responseBody);

            var lat = "";
            var lng = "";
            var enderecoCompleto = "";

            if (dynObj.status == "OK")
            {
                foreach(var data in dynObj.results)
                {
                    lat = data.geometry.location.lat;
                    lng = data.geometry.location.lng;
                    enderecoCompleto = data.formatted_address;
                }
            }

            empresa.Latitute = lat;
            empresa.Longitude = lng;
            empresa.Endereco = enderecoCompleto ?? empresa.Endereco;
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
