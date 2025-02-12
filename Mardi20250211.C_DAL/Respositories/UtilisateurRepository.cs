using Mardi20250211.C_DAL.Helper;
using Mardi20250211.C_DAL.Interfaces;
using Mardi20250211.D_DL.Entities;

namespace Mardi20250211.C_DAL.Respositories
{
    //todo: Ecrire Requête SQL insert as enregistrer utilisateur
    //todo: Ecrire Requête SQL login ici recupérer utilisateur by email et password
    public class UtilisateurRepository : IUtilisateurRepository
    {
        public async Task<bool> LoginByEmailAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterUserAsync(EnregistrerUtilisateur utilisateur)
        {
            if (!String.IsNullOrEmpty(utilisateur.Password))
            {
                string password = PasswordHasher.HashPassword(utilisateur.Password);
                //requet sql insert

                return true;
            }
            return false;
        }
    }
}
