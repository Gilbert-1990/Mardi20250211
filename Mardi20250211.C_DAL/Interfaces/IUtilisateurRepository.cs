using Mardi20250211.D_DL;
using Mardi20250211.D_DL.Entities;

namespace Mardi20250211.C_DAL.Interfaces
{
    public interface IUtilisateurRepository
    {
        //login
        Task<Response<Utilisateur>> LoginByEmailAsync(LoginUtilisateur loginUser);

        //register
        Task<Response<Utilisateur>> RegisterUserAsync(EnregistrerUtilisateur utilisateur);
    }
}
