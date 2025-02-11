using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Mardi20250211.C_DAL.Helper;

public static class PasswordHasher
{
    public static string HashPassword(string password)
    {
        string salt = SHA512.Create(hashName: "furax").ToString();
        // Hacher le mot de passe avec BCrypt
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
        return hashedPassword;
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        // Vérifier le mot de passe avec BCrypt
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}