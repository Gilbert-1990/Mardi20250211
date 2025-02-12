using Mardi20250211.D_DL.Entities;

namespace Mardi20250211.C_DAL.Interfaces
{
    public interface IUtilisateurRepository
    {
        //login
        Task<bool> LoginByEmailAsync(string email, string password);

        //register
        Task<bool> RegisterUserAsync(EnregistrerUtilisateur utilisateur);
    }
}
