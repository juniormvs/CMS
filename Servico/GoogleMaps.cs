using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Servicos
{
    public class GoogleMaps
    {
        private const string urlGeocode = "https://maps.googleapis.com/maps/api/geocode/json?";
        private const string key = "&key=" + Util.KeyIntregracao.GOOGLE_MAPS;

        public async Task<dynamic> GetLatitudeLongitude(string endereco)
        {
            string url = urlGeocode + "address=" + endereco.Replace(" ", "+") + key;

            HttpClient client = new HttpClient();
            
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            JsonSerializer json = new JsonSerializer();

            dynamic dynObj = JsonConvert.DeserializeObject(responseBody);

            return dynObj;
        }
    }
}
