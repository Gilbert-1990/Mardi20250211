using Mardi20250211.B_BLL.Interfaces;
using Mardi20250211.C_DAL.Interfaces;
using Mardi20250211.D_DL.Entities;
using Mardi20250211.D_DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mardi20250211.B_BLL.Services
{
    public class UtilisateurService : IUtilisateurService
    {
        public readonly IUtilisateurRepository _utilisateurrepository;
        public UtilisateurService(IUtilisateurRepository utilisateurrepository)
        {
            _utilisateurrepository = utilisateurrepository;
        }
        public async Task<Response<Utilisateur>> LoginUserAsync(LoginUtilisateur loginUser)
        {
            return await _utilisateurrepository.LoginByEmailAsync(loginUser);
        }

        public async Task<Response<Utilisateur>> RegisterUserAsync(EnregistrerUtilisateur registerUser)
        {
            return await _utilisateurrepository.RegisterUserAsync(registerUser);
        }
    }
}
