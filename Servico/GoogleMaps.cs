using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServicoExterno
{
    public class GoogleMaps
    {
        private const string urlGeocode = "https://maps.googleapis.com/maps/api/geocode/json?";
        private const string key = "&key=AIzaSyBU7wcTnef3GwcAzGTGCrX-1uEwpMRRoM4";

        public async Task<dynamic> GetLatitudeLongitude(string endereco)
        {
            HttpClient client = new HttpClient();

            string address = "address=" + endereco.Replace(" ", "+");
            
            HttpResponseMessage response = await client.GetAsync(urlGeocode + address + key);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            JsonSerializer json = new JsonSerializer();

            dynamic dynObj = JsonConvert.DeserializeObject(responseBody);

            return dynObj;
        }
    }
}
