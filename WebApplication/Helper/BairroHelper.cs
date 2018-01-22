using Model;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Helper
{
    public class BairroHelper
    {
        public static SelectList MontarListaBairro(List<Bairro> bairros)
        {
            List<ViewBairro> retorno = new List<ViewBairro>();

            int count = 0;
            foreach (var item in bairros)
            {
                count++;

                ViewBairro vb = new ViewBairro()
                {
                    Id = count,
                    Bairro = item.Nome,
                    Url = Util.Texto.FormatarParaURLAmigavel(item.Nome)
                };

                retorno.Add(vb);
            }

            return new SelectList(retorno, "Url","Bairro");
        }
    }
}