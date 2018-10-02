using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VenteProjet.Models
{
    public class ClientM
    {
            private siteventeEntities db = new siteventeEntities();
            public List<string> getClient(string nom)
            {
                return db.Clients.Where(x => x.Nom.StartsWith(nom)).Select(x => x.Nom).ToList();
            }
        
    }
}