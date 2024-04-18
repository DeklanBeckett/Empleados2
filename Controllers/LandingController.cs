using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Login.Data;
using Login.Models;

namespace Empleados.Controllers
{
    public class LandingController : Controller
    {
        private readonly DatabaseContext _context;

        public LandingController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logins(string correo, string contraseña)
        {
            
            var usuario = _context.Empleados.FirstOrDefault(u => u.correo == correo);
            if (usuario != null && usuario.contraseña == contraseña)
            {
                HttpContext.Session.SetString("Nombre", usuario.nombre);
                HttpContext.Session.SetInt32("Id", usuario.id);
                return RedirectToAction("Index", "Empleados");
            }
            else
            {
                
                ViewBag.Error = "Correo electonico o contraseña incorrectos";
                return RedirectToAction("Index", "Landing");
            }
        }
    }
}