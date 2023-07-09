using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using static PortFolio.DAL.Models.GetSoluzioneViaggio;

namespace DarisAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StazioniTreniController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public StazioniTreniController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(Name = "GetStazioni")]
        public List<Stazione> Get(string nome)
        {
            try
            {
                //var cookie = Request.Headers.GetCookies("RicercaTreni").FirstOrDefault();

                // estrepolo la stazione in base al nome indicato
                string api = "https://www.lefrecce.it/Channels.Website.BFF.WEB/website/locations/search?name=" + nome + "&limit=100";
                var request = (HttpWebRequest)WebRequest.Create(api);
                request.ContentType = "application/json";
                request.Method = "GET";

                WebResponse response = request.GetResponse() as HttpWebResponse;
                var stream = response.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream);
                // Leggo la risposta.
                string streamJson2 = reader2.ReadToEnd();
                var listaStazioni = JsonConvert.DeserializeObject<List<Stazione>>(streamJson2);

                return listaStazioni;
            }
            catch (Exception exc)
            {
                return null;
            }
        }
    }
}
