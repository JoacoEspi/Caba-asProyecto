using CabañasProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace CabañasProyecto.Controllers
{
    public class LoginController : Controller
    {
        CabaniasContext context = new();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                // Encriptar cotraseña
                string contraseniaEncriptada = Encriptar(login.Contrasenia);
                var loginUsuario = context.Login.Where(l => l.Usuario == login.Usuario && l.Contrasenia == contraseniaEncriptada ).FirstOrDefault();   
                
                if(loginUsuario != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["Error Login"] = "Los datos ingresados son incorrectos";
                    return View("Index");
                }    
            }
            return View("Index");
        }

        public string Encriptar(string contra)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contra));

                StringBuilder stringBuilder = new();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }

    }
}
