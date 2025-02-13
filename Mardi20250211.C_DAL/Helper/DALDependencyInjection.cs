using Mardi20250211.C_DAL.Interfaces;
using Mardi20250211.C_DAL.Respositories;
using Microsoft.Extensions.DependencyInjection;

namespace Mardi20250211.C_DAL.Helper;
/// <summary>
/// Les services/repositories sont présent
/// </summary>
public static class DALDependencyInjection
{
    /// <summary>
    /// Cette fonction implemente tous les services de la data access layer
    /// </summary>
    /// <param name="services"> IServiceCollection</param>
    public static void RegisterServicesRepository(IServiceCollection services)
    {
        services.AddScoped<ISqlServicesConnectionFactory, SqlServicesConnectionFactory>();
        services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();
    }
}