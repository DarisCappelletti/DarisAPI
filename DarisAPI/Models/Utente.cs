//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PortFolio.DAL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Utente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public string NomeUtente { get; set; }
        public byte[] Password { get; set; }
        public byte[] Chiave { get; set; }
    }
}
