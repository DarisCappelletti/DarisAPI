using Microsoft.AspNetCore.Mvc;
using PortFolio.BLL.Helpers;
using PortFolio.DAL.Models;

namespace DarisAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComuniItalianiController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ComuniItalianiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(Name = "GetComuniItaliani")]
        // GET api/ComuniItaliani
        public List<Comune> Get(string comune = null, bool datiIndicePA = false, bool datiWikiData = false)
        {
            var auth_indicePA = _configuration["AppSettings:indicePa.authID"];
            // Ritorno la lista dei comuni italiani
            return ComuniItalianiHelper.RicercaComuniIstat(auth_indicePA, comune, datiIndicePA, datiWikiData);
        }
    }
}
