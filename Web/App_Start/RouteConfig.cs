using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Detalhe",
                "Imovel/{Id}/{urlAmigavel}",
                new { controller = "Imovel", action = "Detalhe", urlAmigavel = UrlParameter.Optional },
                new[] { "Web.Controllers" }
            );

            routes.MapRoute(
                "ImovelPorContrato",
                "Contrato/{urlAmigavelContrato}",
                new { controller = "Imovel", action = "ImovelPorContrato" },
                new[] { "Web.Controllers" }
            );

            routes.MapRoute(
                "ImovelPorTipo",
                "Tipo/{urlAmigavelTipo}",
                new { controller = "Imovel", action = "ImovelPorTipo" },
                new[] { "Web.Controllers" }
            );

            routes.MapRoute(
                "ImovelParaVendaPorTipo",
                "Venda/{tipo}",
                new { controller = "Imovel", action = "ImovelParaVendaPorTipo" },
                new[] { "Web.Controllers" }
            );

            routes.MapRoute(
                "ImovelParaAluguelPorTipo",
                "Aluguel/{tipo}",
                new { controller = "Imovel", action = "ImovelParaAluguelPorTipo" },
                new[] { "Web.Controllers" }
            );

            routes.MapRoute(
                "Exibir",
                "Publicacao/{titulo}",
                new { controller = "Publicacao", action = "Exibir" },
                new[] { "Web.Controllers" }
            );

            routes.MapRoute(
                "ExibirCategoria",
                "Categoria/{categoria}",
                new { controller = "Categoria", action = "Exibir" },
                new[] { "Web.Controllers" }
            );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Web.Controllers" }
            );
        }
    }
}
