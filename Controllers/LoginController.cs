using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DestinoCertoMVC.Data;
using DestinoCertoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DestinoCertoMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly DCDBContext _context;

        public LoginController(DCDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/Home/Login.cshtml");
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Usuarios.FirstOrDefault(u =>
                    u.Login == model.Login && u.Senha == model.Senha
                );

                if (user != null)
                {
                    return RedirectToAction("PainelUsuario", "Home");
                }
                else
                {
                    // Credenciais inválidas
                    ModelState.AddModelError(string.Empty, "Tentativa de login inválida.");
                }
            }

            return View("~/Views/Home/Index.cshtml", model);
        }
    }
}
