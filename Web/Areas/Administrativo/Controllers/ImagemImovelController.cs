using BLL;
using BLL.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Util;

namespace Web.Areas.Administrativo.Controllers
{
    public class ImagemImovelController : Controller
    {
        IImagemImovelBll _bll;

        public ImagemImovelController()
        {
            _bll = new ImagemImovelBll();
        }

        // GET: Administrativo/ImagemImovel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarImagens(int? imovelId)
        {
            return View(_bll.Listar(imovelId.GetValueOrDefault()));
        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(string imagem)
        {
            var imagemImovel = _bll.Obter(imagem);

            string status = string.Empty;
            string msg = string.Empty;

            if (imagemImovel != null)
            {
                _bll.Excluir(imagemImovel);
                status = "success";
                msg = "registro excluído com sucesso";
            }
            else
            {
                status = "error";
                msg = "ocorreu um erro ao excluir o registro";
            }

            DeletarArquivo(imagem);
            
            var retorno = new { status = status, menssage = msg };
            return Json(retorno);
        }

        #region MANIPULACAO_DE_ARQUIVOS

        private void DeletarArquivo(string nome)
        {
            System.IO.File.Delete(Server.MapPath(Constants.IMG_IMOVEL + nome));
            System.IO.File.Delete(Server.MapPath(Constants.IMG_IMOVEL + nome.Replace(Constants.JPG, Constants.THUMB_JPG)));
        }

        public ActionResult UploadPage()
        {
            return PartialView();
        }


        //TODO multiupload
        //fazer upload das imagens para um diretorio temporario
        //listar essas imagens e salvar somente depois de ter salvo o imovel
        [HttpPost]
        public ActionResult Upload()
        {
            IImagemImovelBll _imagemImovelBll = new ImagemImovelBll();
            
            bool fotoSalvaComSucesso = false;
            string fotoNome = String.Empty;
            string erro = String.Empty;

            string nomeArquivo = string.Empty;

            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase arquivo = Request.Files[fileName];
                    fotoNome = arquivo.FileName;

                    if (arquivo == null && arquivo.ContentLength <= 0)
                    {
                        continue;
                    }

                    var diretorioOriginal = new DirectoryInfo(string.Format("{0}Content\\upload\\temp\\", Server.MapPath(@"\")));
                    string pathString = Path.Combine(diretorioOriginal.ToString());

                    if (!Directory.Exists(pathString))
                    {
                        Directory.CreateDirectory(pathString);
                    }

                    nomeArquivo = Guid.NewGuid().ToString();// 123sadf2341sdf
                    string nomeArquivoThumb = nomeArquivo + Constants.THUMB;// 123sadf2341sdf_thumb

                    var path = string.Format("{0}\\{1}", pathString, nomeArquivo + Constants.JPG); // /Content/upload/album/123sadf2341sdf.jpg
                    arquivo.SaveAs(path);

                    string arquivoOriginal = path;// /Content/upload/album/123sadf2341sdf.jpg
                    string arquivoTemporario = path.Replace(Constants.JPG, Constants.TEMP_JPG); // /Content/upload/album/123sadf2341sdf_temp.jpg
                    arquivo.SaveAs(arquivoTemporario);

                    FileStream fileStream = new FileStream(arquivoTemporario, FileMode.Open);

                    GerarThumb(fileStream, pathString.Replace(Constants.JPG, String.Empty), 400, 400);
                    

                    fileStream.Flush();
                    fileStream.Close();
                    fileStream.Dispose();
                    System.IO.File.Delete(arquivoTemporario);

                    fotoSalvaComSucesso = true;
                }
            }
            catch (Exception e)
            {
                //log.Error("Error message: " + e.Message + " - " + e.StackTrace);
                fotoSalvaComSucesso = false;
                erro = e.Message;
            }

            if (fotoSalvaComSucesso)
            {
                return Json(new { Message = fotoNome, NomeArquivo = nomeArquivo + Constants.JPG, Status = "success" });
            }
            else
            {
                return Json(new { Message = "Erro ao salvar arquivo " + erro, Status = "error" });
            }
        }

        private void GerarThumb(FileStream novoArquivo, string DiretorioArquivoSemExtensao, double alturaMaxima, double larguraMaxima)
        {
            try
            {
                //variavel para conversao
                float proporcao;

                //cria uma variavel para armazenar a imagem
                Image image = Image.FromStream(novoArquivo);

                //pegar a altura e largura da imagem
                int largura = image.Width;
                int altura = image.Height;

                //conversao para o novo tamanho
                if (largura > altura)
                {
                    proporcao = largura / (float)larguraMaxima;
                    largura = (int)(largura / proporcao);
                    altura = (int)(altura / proporcao);
                }

                if (altura > largura)
                {
                    proporcao = altura / (float)alturaMaxima;
                    largura = (int)(largura / proporcao);
                    altura = (int)(altura / proporcao);
                }

                if (altura == largura)
                {
                    altura = (int)alturaMaxima;
                    largura = (int)larguraMaxima;
                }

                //cria uma imagem em branco para ser 'desenhada', a nova imagem
                Bitmap bitmap = new Bitmap(largura, altura);
                Graphics graphics = Graphics.FromImage(bitmap);
                SolidBrush solidBrush = new SolidBrush(Color.White);

                //preenchimento da imagem em branco com a imagem original
                graphics.FillRectangle(solidBrush, 0, 0, bitmap.Width, bitmap.Height);
                graphics.DrawImage(image, 0, 0, bitmap.Width, bitmap.Height);

                solidBrush.Dispose();
                graphics.Dispose();
                image.Dispose();

                string nomeImagem = novoArquivo.Name;

                nomeImagem = nomeImagem.Replace(Constants.TEMP_JPG, Constants.THUMB_JPG);
                bitmap.Save(nomeImagem, System.Drawing.Imaging.ImageFormat.Jpeg);

                bitmap.Dispose();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e);
                //log.Error("Error message: " + e.Message + " - " + e.StackTrace);
                throw;
            }
        }

        [HttpPost]
        [ActionName("ordenar")]
        public JsonResult Ordernar(List<ImagemImovel> imagens)
        {
            IImagemImovelBll imagemImovelBll = new ImagemImovelBll();
            if (imagens != null)
            {
                foreach (ImagemImovel img in imagens)
                {
                    imagemImovelBll.Atualizar(img);
                }
                return Json("Ordenado com sucesso");
            }
            else
            {
                return Json("Ocorreu um erro ao ordenar");
            }
        }

        #endregion MANIPULACAO_DE_ARQUIVOS
    }
}