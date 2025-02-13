using Mardi20250211.D_DL;
using Mardi20250211.D_DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mardi20250211.B_BLL.Interfaces
{
    public interface IUtilisateurService
    {
        Task<Response<Utilisateur>> LoginUserAsync(LoginUtilisateur loginUser);
        Task<Response<Utilisateur>> RegisterUserAsync(EnregistrerUtilisateur registerUser);
    }
}