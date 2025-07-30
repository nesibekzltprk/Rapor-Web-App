using Microsoft.AspNetCore.Mvc;
using RaporFront.Models;

namespace RaporFront.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View(); // Views/Login/Login.cshtml
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // Doğrulama işlemleri burada yapılabilir
            return RedirectToAction("Index", "Raporlar");
        }

        
    }
}
