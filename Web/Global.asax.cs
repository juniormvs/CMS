using System.Globalization;
using System.Threading;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //configuracao de rota para webapi - primeiro
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
            //configuracao de rota para mvc - segundo
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
        }
    }
}
