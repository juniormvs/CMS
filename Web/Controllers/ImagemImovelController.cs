using BLL;
using BLL.Interface;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ImagemImovelController : Controller
    {
        IImagemImovelBll _bll;

        public ImagemImovelController()
        {
            _bll = new ImagemImovelBll();
        }

        public ActionResult ListarImagens(int? imovelId)
        {
            return PartialView(_bll.Listar(imovelId.GetValueOrDefault()));
        }
    }
}