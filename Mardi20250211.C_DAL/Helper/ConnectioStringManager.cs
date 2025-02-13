using Mardi20250211.C_DAL.Resources;
using Microsoft.Extensions.Configuration;
using System.Resources;

namespace Mardi20250211.C_DAL.Helper
{
    public static class ConnectioStringManager
    {
        public static string GetCustomConnectionString(IConfiguration _configuration)
        {
            // Lire l'environnement actuel (Production, Development...)
            string env = _configuration["ASPNETCORE_ENVIRONMENT"] ?? "Production";

            string? connectionString = _configuration.GetConnectionString("LaboConnectionString");

            // Si on est en développement, on change certains paramètres
            if (env == "Development")
            {
                // Charger User ID et Password depuis Resources.resx
                string Id = SharedResources.Valeur1;
                string pwd = SharedResources.Valeur2;
                string srvr = SharedResources.Valeur3;
                string ctg = SharedResources.Valeur4;
                // Connection string de base
                //"Data Source=srvr;Initial Catalog=ctg; User Id=ulg; Password=uplg;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"
                //connectionString = $"Server=MON_SERVEUR;Database=MA_BASE;User ID={Id};Password={pwd};TrustServerCertificate=True;";

                connectionString = connectionString.Replace("{0}", srvr).Replace("{1}", ctg).Replace("{2}", Id).Replace("{3}", pwd);
            }

            return connectionString;
        }
    }
}
