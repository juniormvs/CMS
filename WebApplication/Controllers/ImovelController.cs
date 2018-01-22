using BLL;
using BLL.Interface;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;
using Util;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ImovelController : Controller
    {
        IImovelBll _imovelBll;
        ITipoContratoBll _contratoBll;
        ITipoImovelBll _tipoBll;
        IStatusBll _statusBll;
        ICidadeBll _cidadeBll;
        IBairroBll _bairroBll;
        IEmpresaBll _empresaBll;

        public ImovelController()
        {
            _imovelBll = new ImovelBll();
            _contratoBll = new TipoContratoBll();
            _tipoBll = new TipoImovelBll();
            _statusBll = new StatusBll();
            _cidadeBll = new CidadeBll();
            _bairroBll = new BairroBll();
            _empresaBll = new EmpresaBll();
        }

        // GET: Imovel
        public ActionResult Index()
        {
            var imoveis = _imovelBll.ListarAtivos()
                                    .Include(x => x.Status)
                                    .Include(x => x.TipoImovel)
                                    .Include(x => x.TipoContrato)
                                    .OrderByDescending(x => x.Id);
            return View(imoveis);
        }
        
        public ActionResult Detalhe(int id, string urlAmigavel)
        {
            var imovel = _imovelBll.Obter(id);

            if(imovel == null)
            {
                TempData[Constants.MENSAGEM] = "O imóvel que você selecionou, não está mais disponível. Por favor, procure outro.";
                TempData[Constants.CSS_CLASS] = Constants.DANGER;
            }

            return View(imovel);
        }

        
        #region ListasDeImoveis

        public ActionResult ImovelPorContrato(string urlAmigavelContrato)
        {
            var tipoContrato = _contratoBll.ObterPorUrl(urlAmigavelContrato);

            var imoveis = _imovelBll.ListarPorContrato(tipoContrato.Id)
                                    .Where(x => x.StatusId == Constants.STATUS_ATIVO_ID)
                                    .Include(x => x.Status)
                                    .Include(x => x.TipoImovel)
                                    .Include(x => x.TipoContrato)
                                    .OrderByDescending(x => x.Id);
            return View(imoveis);
        }

        public ActionResult ImovelPorTipo(string urlAmigavelTipo)
        {
            var tipoImovel = _tipoBll.ObterPorUrl(urlAmigavelTipo);

            var imoveis = _imovelBll.ListarPorTipo(tipoImovel.Id)
                                .Where(x => x.StatusId == Constants.STATUS_ATIVO_ID)
                                .Include(x => x.Status)
                                .Include(x => x.TipoImovel)
                                .Include(x => x.TipoContrato)
                                .OrderByDescending(x => x.Id);
            return View(imoveis);
        }

        public ActionResult ImovelPorCidade(string urlAmigavelCidade)
        {
            //TODO listar por cidade
            return View();
        }

        public ActionResult ImovelPorBairro(string urlAmigavelBairro)
        {
            //TODO listar por bairro
            return View();
        }

        public ActionResult ImovelParaVendaPorTipo(string tipo)
        {
            var tipoImovel = _tipoBll.ObterPorUrl(tipo);


            var imoveis = _imovelBll.ListarPorTipo(tipoImovel.Id)
                                .Where(x => x.StatusId == Constants.STATUS_ATIVO_ID)
                                .Where(x => x.TipoContratoId == Constants.ID_VENDA)
                                .Include(x => x.Status)
                                .Include(x => x.TipoImovel)
                                .Include(x => x.TipoContrato)
                                .OrderByDescending(x => x.Id);

            ViewBag.Titulo = tipoImovel.Nome;
            return View(imoveis);
        }

        public ActionResult ImovelParaAluguelPorTipo(string tipo)
        {
            var tipoImovel = _tipoBll.ObterPorUrl(tipo);
            
            var imoveis = _imovelBll.ListarPorTipo(tipoImovel.Id)
                                .Where(x => x.StatusId == Constants.STATUS_ATIVO_ID)
                                .Where(x => x.TipoContratoId == 2)
                                .Include(x => x.Status)
                                .Include(x => x.TipoImovel)
                                .Include(x => x.TipoContrato)
                                .OrderByDescending(x => x.Id);

            ViewBag.Titulo = tipoImovel.Nome;
            return View(imoveis);
        }


        #endregion

        #region partialViews
        public ActionResult ListaDeCategorias()
        {
            var categorias = _tipoBll.Listar().OrderBy(x => x.Nome);
            return PartialView(categorias);
        }

        public ActionResult ListaDeContratos()
        {
            return PartialView(_contratoBll.Listar().OrderBy(x => x.Nome));
        }

        public ActionResult PropriedadesRecentes(int quantidade)
        {
            var imoveis = _imovelBll.ListarAtivos()
                                    .Include(x => x.Status)
                                    .Include(x => x.TipoImovel)
                                    .Include(x => x.TipoContrato)
                                    .OrderByDescending(x => x.Id)
                                    .Take(quantidade);

            return PartialView(imoveis);
        }


        #endregion

        #region EnviarMensagens

        [HttpPost]
        public JsonResult Detalhe([Bind(Include = @"ImovelId, UrlAmigavel, ImovelTitulo, ImovelUrl, 
                                        Remetente, Email, Telefone, Mensagem")] Proposta proposta)
        {
            dynamic retorno = null;

            proposta.Destinatario = _empresaBll.Obter(1).Email;

            if (string.IsNullOrEmpty(proposta.Mensagem))
            {
                proposta.Mensagem = "Olá!Achei esse imóvel através do site www.imobiliariaprudente.com.br.Por favor, gostaria de mais informações sobre o mesmo.Aguardo contato. Grato.";
            }

            try
            {
                SmtpClient smtpClient = new SmtpClient();

                var mailMessage = ConfigurarMensagem(proposta);

                smtpClient.Port = 587;
                smtpClient.Host = "smtp.mainsoftware.com.br";
                smtpClient.Credentials = new System.Net.NetworkCredential("email@mainsoftware.com.br", "Mvtmjsunp@87");
                smtpClient.Send(mailMessage);
                mailMessage.Dispose();

                retorno = new { status = "success", msg = "Sua mensagem foi enviada com sucesso!" };
            }
            catch (Exception e)
            {
                retorno = new { status = "error", msg = "Ocorreu um erro ao enviar a mensage. Por favor, tente novamente.", error = e.Message };
            }

            ExibirMensagem("Sua mensagem foi enviada com sucesso!", Constants.SUCCESS);
            
            return Json(retorno);
        }

        private MailMessage ConfigurarMensagem(Proposta proposta)
        {
            MailMessage mailMessage = new MailMessage();
            MailAddress mailAddress = new MailAddress(proposta.Remetente + " <email@mainsoftware.com.br>");

            mailMessage.Bcc.Add("ericosouza87@outlook.com");

            mailMessage.Subject = "Proposta para imóvel " + proposta.ImovelId + " | " + proposta.ImovelTitulo;
            mailMessage.From = mailAddress;
            mailMessage.ReplyToList.Add(proposta.Destinatario);
            mailMessage.Priority = MailPriority.High;
            mailMessage.IsBodyHtml = true;

            StringBuilder mensagem = new StringBuilder();
            mensagem.Append("<h3>Proposta enviada pelo site, por " + proposta.Remetente + " </h3>").Append(Environment.NewLine);
            mensagem.Append("<hr/>").Append(Environment.NewLine);
            mensagem.Append("<p><strong>Imóvel: </strong> <a href='"+proposta.ImovelUrl+"'/>"+proposta.ImovelId + " | " + proposta.ImovelTitulo +"</a></p>").Append(Environment.NewLine);
            mensagem.Append("<p><strong>Remetente: </strong>" + proposta.Remetente + "("+proposta.Email+")</p>").Append(Environment.NewLine);
            mensagem.Append("<p><strong>Telefone: </strong>" + proposta.Telefone + "</p>").Append(Environment.NewLine);

            mensagem.Append("<hr/>").Append(Environment.NewLine);
            mensagem.Append("<p>Mensagem:</p>").Append(Environment.NewLine);
            mensagem.Append("<p>" + proposta.Mensagem + "</p>").Append(Environment.NewLine);

            mailMessage.Body = mensagem.ToString();
            return mailMessage;
        }

        private void ExibirMensagem(string mensagem, string tipo)
        {
            TempData[Constants.MENSAGEM] = mensagem;
            TempData[Constants.CSS_CLASS] = tipo;
        }

#endregion
    }
}