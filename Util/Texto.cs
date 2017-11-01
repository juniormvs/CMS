using System.Globalization;
using System.Text;

namespace Util
{
    public class Texto
    {
        public static string RemoverAcentuacao(string expressao)
        {
            StringBuilder retorno = new StringBuilder();
            var texto = expressao.Normalize(NormalizationForm.FormD).ToCharArray();

            foreach (char caracter in texto)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(caracter) != UnicodeCategory.NonSpacingMark)
                {
                    retorno.Append(caracter);
                }
            }
            return retorno.ToString();
        }

        public static string FormatarParaURLAmigavel(string texto)
        {
            if (texto == null) return null;

            texto = RemoverAcentuacao(texto);
            texto = RemoverCaracteresEspeciais(texto);

            texto = texto.Replace(" ", "-").ToLower();
            
            do
            {
                texto = texto.Replace("--", "-");
            } while (texto.Contains("--"));

            return texto;
        }

        public static string RemoverCaracteresEspeciais(string texto)
        {
            string caracterEspecial = "~!@#$%^&*<()+=:`',.?>/\\\"";
            string[] retorno = texto.Split(caracterEspecial.ToCharArray());

            return string.Concat(retorno).Trim();
        }
    }
}
