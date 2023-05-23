using Backend.Db;
using Backend.Models.Requests.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Backend.Controllers
{
    public class AuthController : Controller
    {
        private readonly DbHelper _dbHelper;


        public AuthController(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public IActionResult Login(LoginRequest request)
        {
            request.Password = ComputeSHA256(request.Password);
            _dbHelper.Login(request);

            return Ok();
        }

        public IActionResult Logout(LogoutRequest request)
        {
            return Ok();
        }

        public IActionResult Register(RegisterRequest request)
        {
            request.Password = ComputeSHA256(request.Password);
            request.RepeatPassword = ComputeSHA256(request.RepeatPassword);
            if (request.Password == request.RepeatPassword)
            {
                _dbHelper.Register(request);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        private static string ComputeSHA256(string password)
        {
            var hash = string.Empty;
            using (var sha256 = SHA256.Create())
            {
                var hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                foreach (var b in hashValue)
                {
                    hash += $"{b:X2}";
                }
            }

            return hash;
        }
    }
}
