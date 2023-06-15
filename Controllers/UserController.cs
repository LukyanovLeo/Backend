using Backend.Db;
using Backend.Models.Requests;
using Backend.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Backend.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly DbHelper _dbHelper;


        public UserController(IDbHelper dbHelper)
        {
            _dbHelper = (DbHelper)dbHelper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            request.Password = ComputeSHA256(request.Password).ToLower();

            var response = await _dbHelper.Login(request);
            if (response.Login is null)
            {
                return new LoginResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Неправильный логин и/или пароль",
                };
            }

            return response;
        }

        [HttpPost]
        [Route("register")]
        public async Task<LoginResponse> Register(RegisterRequest request)
        {
            request.Password = ComputeSHA256(request.Password).ToLower();
            request.RepeatPassword = ComputeSHA256(request.RepeatPassword).ToLower();

            if (request.Password == request.RepeatPassword)
            {
                if (_dbHelper.CheckLogin(request.Login).IsLoginExists)
                {
                    return new LoginResponse
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Такой логин уже занят.",
                    };
                }
                var response = await _dbHelper.Register(request);

                response.StatusCode = HttpStatusCode.OK;
                return response;
            }
            else
            {
                return new LoginResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Error",
                };
            }
        }

        [HttpPost]
        [Route("avatar")]
        public async Task<UploadAvatarResponse> UploadAvatar(UploadAvatarRequest request)
        {
            return null;
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
