//using Microsoft.AspNetCore.Mvc;
//using PortFolio.BLL.Helpers;
//using PortFolio.DAL.Models;

//namespace DarisAPI.Controllers
//{
//    public class IgUpdateUtentiController : ControllerBase
//    {
//        // GET: IgUpdateUtenti
//        public void Get()
//        {
//            DarisCappellettiEntities db = new DarisCappellettiEntities();
//            var utenti = db.UtenteIg.ToList();

//            foreach (var utente in utenti)
//            {
//                if(utente.Followers == 0)
//                {
//                    IgHelper.updUtente(db, utente);
//                }
//            }

//        }
//    }
//}