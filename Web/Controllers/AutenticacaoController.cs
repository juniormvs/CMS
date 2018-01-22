using BLL;
using BLL.Interface;
using Model;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        private IUsuarioBll _usuarioBll;

        public AutenticacaoController()
        {
            _usuarioBll = new UsuarioBll();
        }

        // GET: Autenticacao
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users usuario, string returnUrl)
        {
            if (!Validar(usuario))
            {
                TempData["error"] = "Por favor, informe o usuário e a senha";
                return View(usuario);
            }

            if (_usuarioBll.Autenticar(usuario))
            {
                FormsAuthentication.SetAuthCookie(usuario.Email, false);
                
                LembrarProximoLogin(usuario.Email);

                if (VerificarUrlRetorno(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return Redirect(FormsAuthentication.DefaultUrl);
            }
            else
            {
                ModelState.AddModelError("", "Usuário ou senha incorretos");
                return View(usuario);
            }
        }

        private bool Validar(Users usuario)
        {
            bool retorno = true;
            if (usuario.Email == null)
            {
                retorno = false;
            }

            if (usuario.Email.Equals(string.Empty))
            {
                retorno = false;
            }
            if (usuario.PasswordHash == null)
            {
                retorno = false;
            }

            if (usuario.PasswordHash.Equals(string.Empty))
            {
                retorno = false;
            }
            return retorno;
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Autenticacao");
        }

        /// <summary>
        /// Método que verifica se o sistema deve lembrar do usuário no
        /// próximo acesso.
        /// </summary>
        private void LembrarProximoLogin(string email)
        {
            var lembrar = Request.Form["checkLembrar"];
            if (lembrar != null)
            {
                FormsAuthentication.SetAuthCookie(email, true);
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(email, true, 10080);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                cookie.Expires = authTicket.Expiration;
                cookie.Path = FormsAuthentication.FormsCookiePath;
                HttpContext.Response.Cookies.Set(cookie);
            }
        }

        /// <summary>
        /// Verifica se o login já possui uma url de retorno válida
        /// </summary>
        /// <param name="returnUrl">Url de retorno</param>
        /// <returns>True/False</returns>
        private bool VerificarUrlRetorno(string returnUrl)
        {
            return Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1
                   && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//")
                   && !returnUrl.StartsWith("/\\");
        }

        public JsonResult EnviarSenha(Users usuario)
        {
            string mensagem;
            string status;
            if (usuario.Email == null)
            {
                mensagem = "Por favor, informe um e-mail válido";
                status = "erro";
            }
            else
            {
                if (_usuarioBll.RecuperarSenhaPorEmail(usuario))
                {
                    mensagem = "Senha enviado com sucesso para " + usuario.Email + ". Verifique sua caixa de e-mail.";
                    status = "sucesso";
                }
                else
                {
                    mensagem = "Ocorreu um erro durante a solicitação. Entre em contato com o desenvolvedor.";
                    status = "erro";
                }
            }

            var resultado = new
            {
                Mensagem = mensagem,
                Status = status
            };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}