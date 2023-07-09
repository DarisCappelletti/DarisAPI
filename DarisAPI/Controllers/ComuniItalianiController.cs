using Microsoft.AspNetCore.Mvc;
using PortFolio.BLL.Helpers;
using PortFolio.DAL.Models;

namespace DarisAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComuniItalianiController : ControllerBase
    {
        [HttpGet(Name = "GetComuniItaliani")]
        // GET api/ComuniItaliani
        public List<Comune> Get(string comune = null, bool datiIndicePA = false, bool datiWikiData = false)
        {
            // Ritorno la lista dei comuni italiani
            return ComuniItalianiHelper.RicercaComuniIstat(comune, datiIndicePA, datiWikiData);
        }
    }
}
