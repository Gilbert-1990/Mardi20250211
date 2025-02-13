using Mardi20250211.B_BLL.Interfaces;
using Mardi20250211.D_DL;
using Mardi20250211.D_DL.Entities;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mardi20250211.A_PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUtilisateurService _utilisateurservice;

        public AuthController(IUtilisateurService authService)
        {
            _utilisateurservice = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] EnregistrerUtilisateur request)
        {
            try
            {
                Response<Utilisateur> response = await _utilisateurservice.RegisterUserAsync(request);
                if (response == null)
                {
                    return BadRequest(new { message = "Erreur lors de l'inscription" });
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Erreur lors de l'inscription" });
            }

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUtilisateur request)
        {
            Response<Utilisateur> utilisateur = await _utilisateurservice.LoginUserAsync(request);

            if (utilisateur != null)
                return Ok(utilisateur);

            return Unauthorized(new { message = "Email ou mot de passe incorrect" });
        }
    }
}
