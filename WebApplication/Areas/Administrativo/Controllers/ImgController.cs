using BLL;
using BLL.Interface;
using System.Web.Mvc;
using Util;

namespace WebApplication.Areas.Administrativo.Controllers
{
    public class ImgController : Controller
    {
        // GET: Administrativo/Img
        public ActionResult Index()
        {
            return View();
        }

        public FileResult Imovel(int? id)
        {
            if (id == null) return null;

            IImovelBll _bll = new ImovelBll();

            var imovel = _bll.Obter(id.GetValueOrDefault());

            if (imovel == null) return null;

            var imageFile = "";

            if (!string.IsNullOrEmpty(imovel.Imagem))
            {
                imageFile = Server.MapPath(Constants.IMG_IMOVEL + imovel.Imagem);
            }
            else
            {
                imageFile = Server.MapPath(Constants.IMG_IMOVEL + Constants.IMOVEL_SEM_IMAGEM);
            }

            return File(imageFile, "imagem/jpeg");
        }
        
        public FileResult Slide(int? id)
        {
            ISlideBll _bll = new SlideBll();

            if (id == null) return null;

            var slide = _bll.Obter(id.GetValueOrDefault());

            if (slide == null) return null;

            var imageFile = Server.MapPath(Constants.IMG_SLIDE + slide.Imagem);

            System.Diagnostics.Debug.WriteLine(imageFile);

            return File(imageFile, "image/jpeg");
        }

        public FileResult Servico(int? id)
        {
            IServicoBll _bll = new ServicoBll();

            if (id == null) return null;

            var servico = _bll.Obter(id.GetValueOrDefault());

            if (servico == null) return null;

            var imageFile = Server.MapPath(Constants.IMG_SERVICO + servico.Imagem);

            System.Diagnostics.Debug.WriteLine(imageFile);

            return File(imageFile, "image/jpeg");
        }


        public FileResult Publicacao(int? id)
        {
            IPublicacaoBll _bll = new PublicacaoBll();

            if (id == null) return null;

            var publicacao = _bll.Obter(id.GetValueOrDefault());

            if (publicacao == null) return null;

            var imageFile = Server.MapPath(Constants.IMG_PUBLICACAO + publicacao.Imagem);

            return File(imageFile, "image/jpeg");
        }

        public FileResult Pessoa(int? id)
        {
            IPessoaBll _bll = new PessoaBll();

            if (id == null) return null;

            var pessoa = _bll.Obter(id.GetValueOrDefault());

            if (pessoa == null) return null;

            var imageFile = Server.MapPath(Constants.IMG_PESSOA + pessoa.Imagem);

            return File(imageFile, "image/jpeg");
        }

        public FileResult Empresa()
        {
            IEmpresaBll _empresaBll = new EmpresaBll();
            var empresa = _empresaBll.Obter(1);

            if (empresa == null) return null;

            var imageFile = Server.MapPath(Constants.IMG_EMPRESA + empresa.Imagem);

            return File(imageFile, "image/jpeg");
        }

        public FileResult GaleriaUpload(string nome, bool? thumb)
        {
            if (nome.Equals(string.Empty))
            {
                return null;
            }
            string imageFile = string.Empty;

            if (thumb == true)
            {
                imageFile = Server.MapPath(Constants.DIRETORIO_TEMPORARIO + nome.ToLower().Replace(Constants.JPG, Constants.THUMB_JPG));
            }
            else
            {
                imageFile = Server.MapPath(Constants.DIRETORIO_TEMPORARIO + nome);
            }
             
            return File(imageFile, "image/jpeg");
        }

        public FileResult GaleriaImovel(int? id, bool? thumb)
        {
            ImagemImovelBll bll = new ImagemImovelBll();

            if (id == null) return null;

            var foto = bll.Obter(id.GetValueOrDefault());

            if (foto == null) return null;

            string imageFile = string.Empty;

            if (thumb == true)
            {
                imageFile = Server.MapPath(Constants.IMG_IMOVEL + foto.Imagem.Replace(Constants.JPG, Constants.THUMB_JPG));
            }
            else
            {
                imageFile = Server.MapPath(Constants.IMG_IMOVEL + foto.Imagem);
            }

            return File(imageFile, "image/jpeg");
        }
    }
}