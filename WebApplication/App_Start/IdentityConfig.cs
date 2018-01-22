using AspNet.Identity.MySQL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Util;
using WebApplication.Models;

namespace WebApplication
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            //TODO - érico : resolver o encode do HTML
            var text = HttpUtility.HtmlEncode(message.Body);

            var msg = new MailMessage { From = new MailAddress(ConfiguracaoEmail.EMAIL_FROM, ConfiguracaoEmail.NAME_FROM) };

            msg.To.Add(new MailAddress(message.Destination));
            msg.Subject = message.Subject;
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Html));
            
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.mainsoftware.com.br";
            smtpClient.Credentials = new System.Net.NetworkCredential("email@mainsoftware.com.br", "Mvtmjsunp@87");
            smtpClient.Send(msg);

            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Conecte seu serviço de SMS aqui para enviar uma mensagem de texto.
            return Task.FromResult(0);
        }
    }

    // Configure o gerenciador de usuários do aplicativo usado nesse aplicativo. O UserManager está definido no ASP.NET Identity e é usado pelo aplicativo.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configurar a lógica de validação para nomes de usuário
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configurar a lógica de validação para senhas
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configurar padrões de bloqueio de usuário
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Registre dois provedores de autenticação de fator. Este aplicativo usa Telefone e Emails como um passo para receber um código para verificar o usuário
            // Você pode gravar seu próprio provedor e conectá-lo aqui.
            manager.RegisterTwoFactorProvider("Código de telefone", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Seu código de segurança é {0}"
            });
            manager.RegisterTwoFactorProvider("Código de e-mail", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Código de segurança",
                BodyFormat = "Seu código de segurança é {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure o gerenciador de login do aplicativo que é usado neste aplicativo.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
