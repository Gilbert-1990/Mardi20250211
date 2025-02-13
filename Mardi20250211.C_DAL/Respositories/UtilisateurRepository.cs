using Mardi20250211.C_DAL.Helper;
using Mardi20250211.C_DAL.Interfaces;
using Mardi20250211.D_DL;
using Mardi20250211.D_DL.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Mardi20250211.C_DAL.Respositories
{
    //todo: Ecrire Requête SQL insert as enregistrer utilisateur
    //todo: Ecrire Requête SQL login ici recupérer utilisateur by email et password
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private readonly ISqlServicesConnectionFactory _connectionFactory;
        public UtilisateurRepository(ISqlServicesConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<Response<Utilisateur>> LoginByEmailAsync(LoginUtilisateur loginUser)
        {
            Utilisateur userInfo = new();
            if (loginUser == null) { return new Response<Utilisateur> { Success = false, Message = $"Mot de passe et Email non valide" }; }
            try
            {

                using SqlConnection conn = await _connectionFactory.GetConnectionAsync();
                using SqlCommand command = conn.CreateCommand();
                command.CommandText = "freeuser.[sp_login]";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Email", loginUser.Email);
                command.Parameters.AddWithValue("@Password", loginUser.Password);

                using SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.Read())
                {
                    userInfo = new Utilisateur
                    {
                        Id = reader.GetInt32("id"),
                        Email = reader.IsDBNull("Email") ? null : reader.GetString("Email"),
                        Nom = reader.IsDBNull("Nom") ? null : reader.GetString("Nom"),
                        Prenom = reader.IsDBNull("Prenom") ? null : reader.GetString("Prenom")
                    };
                }

                return new Response<Utilisateur> { Success = true, Data = userInfo };

            }
            catch (Exception ex)
            {
                return new Response<Utilisateur> { Success = false, Message = $"Erreur SQL : {ex.Message}" };
            }
        }

        public async Task<Response<Utilisateur>> RegisterUserAsync(EnregistrerUtilisateur utilisateur)
        {
           
            if (utilisateur == null) { return new Response<Utilisateur> { Success = false, Message = $"Modelenregistement non valide" }; }
            try
            {

                using SqlConnection conn = await _connectionFactory.GetConnectionAsync();

                using SqlCommand command = conn.CreateCommand();

                command.CommandText = "freeuser.[sp_register]";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nom", utilisateur.Nom);
                command.Parameters.AddWithValue("@Prenom", utilisateur.Prenom);
                command.Parameters.AddWithValue("@Email", utilisateur.Email);
                command.Parameters.AddWithValue("@Passwd", utilisateur.Password);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                    return new Response<Utilisateur> { Success = true, Data = new Utilisateur { Email = utilisateur.Email, Nom = utilisateur.Nom, Prenom=utilisateur.Prenom} };
                else return new Response<Utilisateur> { Success = false, Message = $"impossible d'enregistrer l'utilisateur" };

            }
            catch (Exception ex)
            {
                return new Response<Utilisateur> { Success = false, Message = $"Erreur SQL : {ex.Message}" };
            }
        }
    }
}
