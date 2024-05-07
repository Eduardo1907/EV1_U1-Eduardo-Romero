using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaginaMercyDevelopers.Models;

namespace PaginaMercyDevelopers.Controllers
{
    public class ClientesHasServiciosController : Controller
    {
        private readonly MydbContext _context;

        public ClientesHasServiciosController(MydbContext context)
        {
            _context = context;
        }

        // GET: ClientesHasServicios
        public async Task<IActionResult> Index()
        {
            var mydbContext = _context.ClientesHasServicios.Include(c => c.ClientesIdclientesNavigation).Include(c => c.ServiciosIdserviciosNavigation);
            return View(await mydbContext.ToListAsync());
        }

        // GET: ClientesHasServicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClientesHasServicios == null)
            {
                return NotFound();
            }

            var clientesHasServicio = await _context.ClientesHasServicios
                .Include(c => c.ClientesIdclientesNavigation)
                .Include(c => c.ServiciosIdserviciosNavigation)
                .FirstOrDefaultAsync(m => m.ClientesIdclientes == id);
            if (clientesHasServicio == null)
            {
                return NotFound();
            }

            return View(clientesHasServicio);
        }

        // GET: ClientesHasServicios/Create
        public IActionResult Create()
        {
            ViewData["ClientesIdclientes"] = new SelectList(_context.Clientes, "Idclientes", "Idclientes");
            ViewData["ServiciosIdservicios"] = new SelectList(_context.Servicios, "Idservicios", "Idservicios");
            return View();
        }

        // POST: ClientesHasServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientesIdclientes,ServiciosIdservicios,Inicio,Termino,Coste,Tecnico,NumeroTecnico,CorreoTecnico,Direccion,ClientesHasServicioscol")] ClientesHasServicio clientesHasServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientesHasServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientesIdclientes"] = new SelectList(_context.Clientes, "Idclientes", "Idclientes", clientesHasServicio.ClientesIdclientes);
            ViewData["ServiciosIdservicios"] = new SelectList(_context.Servicios, "Idservicios", "Idservicios", clientesHasServicio.ServiciosIdservicios);
            return View(clientesHasServicio);
        }

        // GET: ClientesHasServicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClientesHasServicios == null)
            {
                return NotFound();
            }

            var clientesHasServicio = await _context.ClientesHasServicios.FindAsync(id);
            if (clientesHasServicio == null)
            {
                return NotFound();
            }
            ViewData["ClientesIdclientes"] = new SelectList(_context.Clientes, "Idclientes", "Idclientes", clientesHasServicio.ClientesIdclientes);
            ViewData["ServiciosIdservicios"] = new SelectList(_context.Servicios, "Idservicios", "Idservicios", clientesHasServicio.ServiciosIdservicios);
            return View(clientesHasServicio);
        }

        // POST: ClientesHasServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientesIdclientes,ServiciosIdservicios,Inicio,Termino,Coste,Tecnico,NumeroTecnico,CorreoTecnico,Direccion,ClientesHasServicioscol")] ClientesHasServicio clientesHasServicio)
        {
            if (id != clientesHasServicio.ClientesIdclientes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientesHasServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesHasServicioExists(clientesHasServicio.ClientesIdclientes))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientesIdclientes"] = new SelectList(_context.Clientes, "Idclientes", "Idclientes", clientesHasServicio.ClientesIdclientes);
            ViewData["ServiciosIdservicios"] = new SelectList(_context.Servicios, "Idservicios", "Idservicios", clientesHasServicio.ServiciosIdservicios);
            return View(clientesHasServicio);
        }

        // GET: ClientesHasServicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClientesHasServicios == null)
            {
                return NotFound();
            }

            var clientesHasServicio = await _context.ClientesHasServicios
                .Include(c => c.ClientesIdclientesNavigation)
                .Include(c => c.ServiciosIdserviciosNavigation)
                .FirstOrDefaultAsync(m => m.ClientesIdclientes == id);
            if (clientesHasServicio == null)
            {
                return NotFound();
            }

            return View(clientesHasServicio);
        }

        // POST: ClientesHasServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClientesHasServicios == null)
            {
                return Problem("Entity set 'MydbContext.ClientesHasServicios'  is null.");
            }
            var clientesHasServicio = await _context.ClientesHasServicios.FindAsync(id);
            if (clientesHasServicio != null)
            {
                _context.ClientesHasServicios.Remove(clientesHasServicio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesHasServicioExists(int id)
        {
          return (_context.ClientesHasServicios?.Any(e => e.ClientesIdclientes == id)).GetValueOrDefault();
        }
    }
}
