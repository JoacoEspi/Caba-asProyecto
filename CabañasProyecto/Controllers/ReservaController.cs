using CabañasProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Collections.Generic;
using System.Numerics;

namespace CabañasProyecto.Controllers
{

    public class ReservaController : Controller
    {
        // Averiguar como poner un menu desplegable
        [HttpGet]
        public IActionResult Index()
        {
            List<Reserva> reservas = new();
            using (CabaniasContext c = new())
            {
                //Linq
                //List<Cabania> reservas2 = (from ca in c.Cabanias where ca.Estado == true select ca).ToList();
                //reservas = c.Cabanias.Where(pepe => pepe.Estado).ToList(); // sentencia lamba
                reservas = c.Reservas.ToList();
            }
            return View(reservas);
        }
        [HttpGet]
        public IActionResult Create()
        {
            List<Cabania> reservas = new();
            List<Cliente> clientes = new();
            using (CabaniasContext c = new())
            {
                reservas = c.Cabanias.Where(c => !c.Estado).ToList();
                clientes = c.Clientes.ToList();
                ViewBag.Cabanias = reservas;
                ViewBag.Clientes = clientes;
            }
            return View();
        }
       
        [HttpPost]
        public IActionResult Create(Reserva reserva)
        {
            Cabania? cabania = null;
            using (CabaniasContext c = new CabaniasContext())
            {
                //reserva.IdCabania = reserva.Id;
                //reserva.Id = 0;
                c.Reservas.Add(reserva);
                cabania = c.Cabanias.Find(reserva.IdCabania);
                if (cabania != null)
                {
                    cabania.Estado = true;
                    c.SaveChanges();
                }
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(Reserva r)
        {
            Reserva? reserva = null;
            using (CabaniasContext context = new())
            {
                //reserva = (from ca in context.Reservas where ca.IdCabania == Id select ca).FirstOrDefault();
                int idR = r.Id;
                reserva = context.Reservas.Find(idR);
                if (reserva != null)
                {
                    return View(reserva);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            }
        [HttpPost]
        public IActionResult Edit(int id, Reserva reserva)
        {
            using (CabaniasContext context = new())
            {
                if (id != reserva.Id)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    context.Reservas.Update(reserva);
                    context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
        }
        // Cuando eliminas la reserva hay q setear el estado en false de la cabaña
        [HttpGet]
        public IActionResult Delete(Reserva reserva)
        {
            Reserva? r = null;
            Cabania? cabania = null;
            using (CabaniasContext context = new())
            {
                if (reserva != null)
                {
                    int idR = reserva.Id;
                    r = context.Reservas.Find(idR);
                    cabania = context.Cabanias.Find(r.IdCabania);
                    context.Reservas.Remove(r);
                    if(cabania != null)
                    {
                        cabania.Estado = false;
                    }
                    context.SaveChanges();
                }
            }
            return RedirectToAction(nameof(Index));
        }

    }
}

 

