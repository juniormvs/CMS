using BLL;
using BLL.Interface;
using Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class CategoriaPublicacaoController : Controller
    {
        private readonly IPublicacaoBll _publicacaoBll;
        private readonly IStatusBll _statusBll;
        private readonly IPublicacaoPorCategoriaBll _publicacaoPorCategoriaBll;
        private readonly ICategoriaPublicacaoBll _categoriaPublicacaoBll;

        public CategoriaPublicacaoController()
        {
            _statusBll = new StatusBll();
            _publicacaoBll = new PublicacaoBll();
            _publicacaoPorCategoriaBll = new PublicacaoPorCategoriaBll();
            _categoriaPublicacaoBll = new CategoriaPublicacaoBll();
        }
        // GET: Categoria
        public ActionResult Index()
        {
            return View(_publicacaoBll.ListarAtivos().Include(p => p.PublicacaoPorCategoria).Include(p => p.Status).OrderByDescending(p => p.DataPublicacao).ToList());
        }

        public ActionResult Exibir(string categoria)
        {
            CategoriaPublicacao cat = _categoriaPublicacaoBll.ObterPorUrl(categoria);
            ViewBag.TituloPagina = cat.Nome;

            IQueryable<PublicacaoPorCategoria> catPub = _publicacaoPorCategoriaBll.ListarPorCategoria(cat.Id);

            List<int> publicacoesId = new List<int>();

            foreach (var item in catPub)
            {
                publicacoesId.Add(item.PublicacaoId);
            }

            var pubs = _publicacaoBll.ListarPorIds(publicacoesId).Include(p => p.PublicacaoPorCategoria).Include(p => p.Status).OrderByDescending(p => p.DataPublicacao).ToList();

            foreach (var item in pubs)
            {
                System.Diagnostics.Debug.WriteLine(item.Id + " - " + item.Titulo);
            }


            return View(pubs);
        }
    }
}