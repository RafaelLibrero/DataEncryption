using DataEncryption.Models;
using DataEncryption.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DataEncryption.Controllers
{
    public class UsersController : Controller
    {
        private RepositoryCryptography repo;

        public UsersController(RepositoryCryptography repo)
        {
            this.repo = repo;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string userName, string email, string password)
        {
            User user = await this.repo.Register(userName, email, password);
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            User user = await this.repo.LoginUserAsync(email, password);
            if (user != null)
            {
                ViewData["MENSAJE"] = "Inicio de sesión correcto";
            }
            else
            {
                ViewData["MENSAJE"] = "Credenciales incorrectas";
            }

            return View();
        }
    }
}
