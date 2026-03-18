using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pzpp.Models;
using pzpp.Services;

namespace pzpp.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserService _userService = new UserService();
        private readonly PasswordHasher<User> _hasher = new PasswordHasher<User>();

        [HttpPost]
        public IActionResult Register(string username, string email, string password, string confirmPassword)
        {
            if (password != confirmPassword)
                return BadRequest("Hasła nie są takie same");

            if (_userService.UserExists(username))
                return BadRequest("Użytkownik już istnieje");

            var user = new User
            {
                Login = username,
                Email = email
            };

            user.PasswordHash = _hasher.HashPassword(user, password);

            _userService.Add(user);

            return Ok("Rejestracja zakończona sukcesem");
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _userService.GetByLogin(username);

            if (user == null)
                return Unauthorized("Nie ma takiego użytkownika");

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, password);

            if (result == PasswordVerificationResult.Failed)
                return Unauthorized("Nieprawidłowe hasło");

            HttpContext.Session.SetString("user", user.Login);

            user.LastLogin = DateTime.UtcNow;
            var users = _userService.GetAll();
            _userService.SaveAll(users);

            return Ok("Zalogowano");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return Ok("Wylogowano");
        }
    }
}
