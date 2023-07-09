//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using PortFolio.BLL.Helpers;
//using PortFolio.DAL.Models;
//using System.IO.Compression;
//using System.Net;

//namespace DarisAPI.Controllers
//{
//    public class IgCheckFollowersController : ControllerBase
//    {
//        // GET api/Ig
//        public RicercaFollowersIg.Root Get(int id)
//        {
//            DarisCappellettiEntities db = new DarisCappellettiEntities();
//            //var listaFollow = db.Followers.ToList();

//            //foreach(var follower in listaFollow)
//            //{
//            //    follower.IsAncoraFollower = false;
//            //}
//            //db.SaveChanges();

//            bool ciSonoAncoraUtenti = true;
//            int? maxID = 0;
//            while (ciSonoAncoraUtenti)
//            {
//                string api = $"https://www.instagram.com/api/v1/friendships/{id}/followers/?search_surface=follow_list_page&max_id={maxID}";
//                var request = (HttpWebRequest)WebRequest.Create(api);

//                request.ContentType = "application/json";
//                request.Headers.Add("accept-encoding", " gzip, deflate, br");
//                request.Headers.Add("accept-language", " it-IT,it;q=0.6");
//                request.Headers.Add("cookie", " ig_did=F0CF4A4B-65B2-4006-8DC4-627E607D0E26; mid=YzxiTgALAAHNAoZtQUqgcWZJAjqU; datr=uy9sY0gDS725BOIJUPJKNJf-; ds_user_id=268542472; dpr=1.25; csrftoken=ME4hVcaol5muRFiOnUMyi2qOn1N9KqUv; sessionid=268542472%3A03KNvwQnyaFlXf%3A25%3AAYcOmlJEPuRROsx0ehBpT4ybVCQ2IZM7acG0LRDkKg; shbid=\"11945\\054268542472\\0541710835464:01f7370882439842c8b81439c3cddaf22dd03934f9173b79c7ef948d033115dc2e48fa80\"; shbts=\"1679299464\\054268542472\\0541710835464:01f798f6f6eff1b99d6bdb04a63a9efaede2355c78185d13dd70320fe3b873a8d4f55a15\"; rur=\"CLN\\054268542472\\0541710835485:01f7dfa0b039ee223b0e8969e1d8496a77d617c222d061100e080890d23e8ff481cfa1b0\"");
//                request.Headers.Add("sec-ch-ua", " \"Brave\";v=\"111\", \"Not(A:Brand\";v=\"8\", \"Chromium\";v=\"111\"");
//                request.Headers.Add("sec-ch-ua-mobile", " ?0");
//                request.Headers.Add("sec-ch-ua-platform", " \"Windows\"");
//                request.Headers.Add("sec-fetch-dest", " empty");
//                request.Headers.Add("sec-fetch-mode", " cors");
//                request.Headers.Add("sec-fetch-site", " same-origin");
//                request.Headers.Add("sec-gpc", " 1");
//                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36";
//                request.Headers.Add("x-asbd-id", " 198387");
//                request.Headers.Add("x-csrftoken", " U2gA3U4DYuVhxzXKoI7aWV4cyqlC8poU");
//                request.Headers.Add("x-ig-app-id", " 936619743392459");
//                request.Headers.Add("x-ig-www-claim", " hmac.AR2VsJz-RWrU-GsQrRTpQJFYs3vexseuqXnpTPNl95I5pE--");
//                request.Headers.Add("x-reque", "");

//                request.Method = "GET";
//                //request.CookieContainer = cookieContainer;

//                WebResponse response = request.GetResponse() as HttpWebResponse;
//                var stream = response.GetResponseStream();

//                // Controllo se la risposta è codificata con GZIP
//                if (response.Headers["Content-Encoding"]?.ToLower().Contains("gzip") == true)
//                {
//                    // Creo uno stream per la decompressione GZIP
//                    stream = new GZipStream(stream, CompressionMode.Decompress);
//                }

//                StreamReader reader2 = new StreamReader(stream);
//                // Leggo la risposta.
//                string streamJson2 = reader2.ReadToEnd();

//                var listaSoluzioni = JsonConvert.DeserializeObject<RicercaFollowersIg.Root>(streamJson2);

//                IgHelper.checkFollowers(listaSoluzioni, id);

//                if (listaSoluzioni.next_max_id != null)
//                {
//                    maxID += 100;
//                }
//                else
//                {
//                    ciSonoAncoraUtenti = false;
//                }
//            }

//            return null;
//        }

//        public class TipoChiamataIg
//        {
//            public List<RicercaFollowersIg.Root> MyProperty { get; set; }
//        }
//    }
//}
