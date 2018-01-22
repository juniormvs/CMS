using Model;
using System.Collections.Generic;
using System.Web.Mvc;
using Web.Models;

namespace Web.Helper
{
    public class CidadeHelper
    {
        public static SelectList MontarListaCidade(List<Cidade> cidades)
        {
            List<ViewCidade> retorno = new List<ViewCidade>();

            int count = 0;
            foreach (var item in cidades)
            {
                count++;

                ViewCidade vc = new ViewCidade()
                {
                    Id = count,
                    Cidade = item.Nome,
                    Url = Util.Texto.FormatarParaURLAmigavel(item.Nome)
                };

                retorno.Add(vc);
            }

            return new SelectList(retorno, "Url", "Cidade");
        }
    }
}