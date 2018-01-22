using BLL;
using BLL.Interface;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class PublicacaoController : Controller
    {
        private readonly IPublicacaoBll _publicacaoBll;
        private readonly IStatusBll _statusBll;
        private readonly IPublicacaoPorCategoriaBll _publicacaoPorCategoriaBll;
        private readonly ICategoriaPublicacaoBll _categoriaPublicacaoBll;
        private readonly ILinkBll _linkBll;

        public PublicacaoController()
        {
            _statusBll = new StatusBll();
            _publicacaoBll = new PublicacaoBll();
            _publicacaoPorCategoriaBll = new PublicacaoPorCategoriaBll();
            _categoriaPublicacaoBll = new CategoriaPublicacaoBll();
            _linkBll = new LinkBll();
        }

        // GET: Publicacao
        public ActionResult Index()
        {
            return View(_publicacaoBll.ListarAtivos().Include(p => p.PublicacaoPorCategoria).Include(p => p.Status).OrderByDescending(p => p.DataPublicacao).ToList());
        }

        public ActionResult Exibir(string titulo)
        {
            return View(_publicacaoBll.ObterPorUrl(titulo));
        }

        #region menulateral
        public ActionResult Busca()
        {
            return PartialView();
        }
        public ActionResult Categoria()
        {
            return PartialView(_categoriaPublicacaoBll.ListarTodos().OrderBy(c => c.Nome));
        }
        public ActionResult UltimasPublicacoes()
        {
            return PartialView(_publicacaoBll.ListarAtivos().OrderByDescending(x => x.DataPublicacao).Take(4));
        }

        public ActionResult Link()
        {
            return PartialView(_linkBll.ListarAtivos().OrderBy(x => x.Titulo));
        }


        #endregion menulateral
    }
}