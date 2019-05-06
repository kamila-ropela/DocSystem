using DocSystem.DatabaseFiles;
using DocSystem.DatabaseFiles.Helper;
using DocSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;

namespace DocSystem.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LogIn()
        {
            Properties.dbContext = HttpContext.RequestServices.GetService(typeof(DbContext)) as DbContext;
          //  UsersTable.ChangePassword(HashPassword("test", 10));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn([FromForm]User model)
        {
            try
            {
                bool result = CheckIfLoginAndPasswordAreCorrect(model);
                if (result)
                {
                    var logins = UsersTable.GetDataByLogin(model.Login);
                    var data = GetIdAndRole(logins[0].Login);
                    Properties.UserId = data.Item1;
                    Properties.UserRole = data.Item2;
                    if (data.Item2 == 1)
                        return RedirectToAction("DoctorView", "Doctor");
                    else
                        return RedirectToAction("PatientView", "Patient");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public static (int, int) GetIdAndRole(string login)
        {
            var name = login.Substring(0, login.IndexOf('.'));
            var surname = login.Substring(login.IndexOf('.') + 1, login.Length - login.IndexOf('.') - 1);
            var data = UsersTable.GetDataByNameAndSurname(name, surname);



            return (data.Item1, data.Item2);
        }

        public static bool CheckIfLoginAndPasswordAreCorrect(User model)
        {
            var logins = UsersTable.GetDataByLogin(model.Login);
            if (logins == null)
                return false;

            if (CheckIfPasswordMatches(logins[0].Password, model.Password, 10))
                return true;

            return false;
        }

        public static byte[] CrereateSalt(int saltLength)
        {
            byte[] bytes = new byte[saltLength];
            using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(bytes);
            }
            return bytes;
        }

        public static string HashPassword(string password, int saltLength)
        {
            byte[] salt = CrereateSalt(saltLength);
            byte[] hash = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256).GetBytes(100 + saltLength);

            byte[] hashBytes = new byte[100 + saltLength];
            Array.Copy(salt, 0, hashBytes, 0, saltLength);
            Array.Copy(hash, 0, hashBytes, saltLength, 100);
            return Convert.ToBase64String(hashBytes);
        }

        public static bool CheckIfPasswordMatches(string hashedPassword, string newPassword, int saltLength)
        {
            byte[] hashedPasswordBytes = Convert.FromBase64String(hashedPassword);
            byte[] saltBytesFromPassword = new byte[saltLength];
            Array.Copy(hashedPasswordBytes, 0, saltBytesFromPassword, 0, saltLength);
            var pbkdf2 = new Rfc2898DeriveBytes(newPassword, saltBytesFromPassword, 10000, HashAlgorithmName.SHA256);
            byte[] newHash = pbkdf2.GetBytes(100 + saltLength);
            for (int i = 0; i < 100; i++)
            {
                if (hashedPasswordBytes[i + saltLength] != newHash[i])
                    return false;
            }
            return true;
        }
    }
}