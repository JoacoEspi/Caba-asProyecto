using CabañasProyecto.Models;
using Microsoft.AspNetCore.Mvc;

namespace CabañasProyecto.Controllers
{
    public class CabaniaController : Controller
    {
       
        [HttpGet]
        public IActionResult Index()
        {
            List<Cabania>? cabanias = null;
            using (CabaniasContext context = new CabaniasContext())
            {
                cabanias = context.Cabanias.ToList();
            }
            return View(cabanias);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cabania cabania)
        {
            using (CabaniasContext context = new())
            {
                if (ModelState.IsValid)
                {
                    context.Cabanias.Add(cabania);
                    context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                return View(cabania);
            }
            
        }

        [HttpGet]

        public IActionResult Edit(int Id)
        {
            Cabania? cabania = null;
            using (CabaniasContext context = new())
            {
                cabania = context.Cabanias.Find(Id);
                if (cabania != null)
                {
                    return View(cabania);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
        }
        [HttpPost]
        public IActionResult Edit(int id, Cabania cab)
        {
            using (CabaniasContext context = new())
            {
                if(id != cab.Id)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    context.Cabanias.Update(cab);
                    context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                return View(cab);
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

                var cabania = context.Cabanias.FirstOrDefault(e => e.Id == id);
                //este metodo le enviamos una propiedad para que pueda realizar la busqueda y devolvernos la primer coincidencia
                //Si no encuentra nada nos devuelve nulo y la asgina a especialidad
                if (cabania == null)
                {
                    return NotFound();
                }
                return View(cabania);
            }
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (CabaniasContext context = new())
            {
                var cabania = context.Cabanias.Find(id);
                context.Cabanias.Remove(cabania);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}

