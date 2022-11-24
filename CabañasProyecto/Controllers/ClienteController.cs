using CabañasProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CabañasProyecto.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Cliente> clientes = null;
            using (CabaniasContext context = new CabaniasContext())
            {
                clientes = context.Clientes.ToList();   
            }
            return View(clientes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            using(CabaniasContext context = new CabaniasContext())
            {
                if (ModelState.IsValid)
                {
                    context.Clientes.Add(cliente);
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(cliente);
            }
           
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            using(CabaniasContext context = new())
            {
                Cliente? cliente = context.Clientes.Find(id);

                if (cliente != null)
                {
                    return View(cliente);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
          
        }
        [HttpPost]
        public IActionResult Edit(int id, Cliente cliente)
        {
          using(CabaniasContext context = new())
            {
                if (id != cliente.Id)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    context.Clientes.Update(cliente);
                    context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                return View(cliente);
            }
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            using (CabaniasContext context = new())
            {
                if (id == null)
                {
                    return NotFound();
                }

                var cliente = context.Clientes.FirstOrDefault(e => e.Id == id);
                //este metodo le enviamos una propiedad para que pueda realizar la busqueda y devolvernos la primer coincidencia
                //Si no encuentra nada nos devuelve nulo y la asgina a especialidad
                if (cliente == null)
                {
                    return NotFound();
                }
                return View(cliente);
            }
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (CabaniasContext context = new())
            {
                var cliente = context.Clientes.Find(id);
                context.Clientes.Remove(cliente);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
    }
    
}
