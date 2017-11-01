using Model;
using System.Collections.Generic;
using System.Web.Mvc;
using Web.Models;

namespace Web.Helper
{
    public class BairroHelper
    {
        public static SelectList MontarListaBairro(List<VwBairro> bairros)
        {
            List<ViewBairro> retorno = new List<ViewBairro>();

            int count = 0;
            foreach (var item in bairros)
            {
                count++;

                ViewBairro vb = new ViewBairro()
                {
                    Id = count,
                    Bairro = item.NomeBairro,
                    Url = item.BairroUrl
                };

                retorno.Add(vb);
            }

            return new SelectList(retorno, "Url","Bairro");
        }
    }
}