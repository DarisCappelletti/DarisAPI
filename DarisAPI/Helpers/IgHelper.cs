//using Newtonsoft.Json;
//using PortFolio.DAL.Models;
//using System.IO.Compression;
//using System.Net;

//namespace PortFolio.BLL.Helpers
//{
//    public static class IgHelper
//    {
//        public static void ImpostaFollower(RicercaFollowersIg.Root listaUtenti, int idFollowato)
//        {
//            DarisCappellettiEntities db = new DarisCappellettiEntities();

//            foreach(var follower in listaUtenti.users)
//            {
//                var utenteIg = db.UtenteIg.FirstOrDefault(x => x.ID == follower.pk_id);
//                if (utenteIg == null)
//                {
//                    db.UtenteIg.Add(new UtenteIg
//                    {
//                        ID = follower.pk_id,
//                        Nome = follower.full_name,
//                        Username = follower.username,
//                        Followers = 0,
//                        Seguiti = 0
//                    });
//                    db.SaveChanges();
//                }
//                else
//                {
//                    utenteIg.Nome = follower.full_name;
//                    utenteIg.Username = follower.username;
//                    utenteIg.Followers = 0;
//                    utenteIg.Seguiti = 0;
//                    db.SaveChanges();
//                }

//                var followUtente = db.Followers.FirstOrDefault(x => x.ID_Utente == follower.pk_id);
//                if (followUtente == null)
//                {
//                    db.Followers.Add(new Followers
//                    {
//                        ID_ProfiloFollowato = idFollowato,
//                        ID_Utente = follower.pk_id,
//                        Nome = follower.username
//                    });
//                    db.SaveChanges();
//                }
//                else
//                {
//                    followUtente.ID_ProfiloFollowato = idFollowato;
//                    followUtente.ID_Utente = follower.pk_id;
//                    followUtente.Nome = follower.username;
//                }
//            }
//        }


//        public static void checkFollowers(RicercaFollowersIg.Root listaUtenti, int idFollowato)
//        {
//            DarisCappellettiEntities db = new DarisCappellettiEntities();

//            foreach (var follower in listaUtenti.users)
//            {
//                var utenteIg = db.UtenteIg.FirstOrDefault(x => x.ID == follower.pk_id);
//                if (utenteIg == null)
//                {
//                    db.UtenteIg.Add(new UtenteIg
//                    {
//                        ID = follower.pk_id,
//                        Nome = follower.full_name,
//                        Username = follower.username,
//                        Followers = 0,
//                        Seguiti = 0
//                    });
//                    db.SaveChanges();
//                }

//                var followUtente = db.Followers.FirstOrDefault(x => x.ID_Utente == follower.pk_id);
//                if (followUtente == null)
//                {
//                    db.Followers.Add(new Followers
//                    {
//                        ID_ProfiloFollowato = idFollowato,
//                        ID_Utente = follower.pk_id,
//                        Nome = follower.username,
//                        IsAncoraFollower = true
//                    });
//                    db.SaveChanges();
//                }
//                else
//                {
//                    followUtente.IsAncoraFollower = true;
//                    db.SaveChanges();
//                }
//            }
//        }

//        public static void updUtente(DarisCappellettiEntities db, UtenteIg ute)
//        {
//            try
//            {
//                string api = $"https://www.instagram.com/api/v1/users/web_profile_info/?username={ute.Username}";
//                var request = (HttpWebRequest)WebRequest.Create(api);

//                request.ContentType = "application/json";
//                request.Headers.Add("accept-encoding", " gzip, deflate, br");
//                request.Headers.Add("accept-language", " it-IT,it;q=0.6");
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

//                var utente = JsonConvert.DeserializeObject<ChiamataUserIg.Root>(streamJson2);

//                if (utente != null)
//                {
//                    var utenteDb = db.UtenteIg.FirstOrDefault(x => x.ID == utente.data.user.id);

//                    if (utenteDb == null)
//                    {
//                        // eliminato?
//                    }
//                    else
//                    {
//                        utenteDb.Followers = utente.data.user.edge_followed_by.count;
//                        utenteDb.Seguiti = utente.data.user.edge_follow.count;
//                        db.SaveChanges();
//                    }
//                }
//            }
//            catch
//            {

//            }
//        }
//    }
//}
