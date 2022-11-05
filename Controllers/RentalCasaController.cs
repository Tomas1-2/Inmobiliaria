using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inmobiliaria.Models;

namespace Inmobiliaria.Controllers
{
    public class RentalCasaController : Controller
    {
        private readonly inmobiliariaContext _context;

        public RentalCasaController(inmobiliariaContext context)
        {
            _context = context;
        }

        // GET: RentalCasa
        public async Task<IActionResult> Index()
        {
            var inmobiliariaContext = _context.RentalCasa.Include(r => r.Casa).Include(r => r.Cliente);
            return View(await inmobiliariaContext.ToListAsync());
        }

        // GET: RentalCasa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RentalCasa == null)
            {
                return NotFound();
            }

            var rentalCasa = await _context.RentalCasa
                .Include(r => r.Casa)
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.RentalCasaId == id);
            if (rentalCasa == null)
            {
                return NotFound();
            }

            return View(rentalCasa);
        }

        // GET: RentalCasa/Create
        public IActionResult Create()
        {
            ViewData["CasaID"] = new SelectList(_context.Casa, "casaID", "casaID");
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "clienteID", "clienteID");
            return View();
        }

        // POST: RentalCasa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalCasaId,FechaAlquiler,ClienteId,CasaID")] RentalCasa rentalCasa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalCasa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CasaID"] = new SelectList(_context.Casa, "casaID", "casaID", rentalCasa.CasaID);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "clienteID", "clienteID", rentalCasa.ClienteId);
            return View(rentalCasa);
        }

        // GET: RentalCasa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RentalCasa == null)
            {
                return NotFound();
            }

            var rentalCasa = await _context.RentalCasa.FindAsync(id);
            if (rentalCasa == null)
            {
                return NotFound();
            }
            ViewData["CasaID"] = new SelectList(_context.Casa, "casaID", "casaID", rentalCasa.CasaID);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "clienteID", "clienteID", rentalCasa.ClienteId);
            return View(rentalCasa);
        }

        // POST: RentalCasa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentalCasaId,FechaAlquiler,ClienteId,CasaID")] RentalCasa rentalCasa)
        {
            if (id != rentalCasa.RentalCasaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalCasa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalCasaExists(rentalCasa.RentalCasaId))
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
            ViewData["CasaID"] = new SelectList(_context.Casa, "casaID", "casaID", rentalCasa.CasaID);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "clienteID", "clienteID", rentalCasa.ClienteId);
            return View(rentalCasa);
        }

        // GET: RentalCasa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RentalCasa == null)
            {
                return NotFound();
            }

            var rentalCasa = await _context.RentalCasa
                .Include(r => r.Casa)
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.RentalCasaId == id);
            if (rentalCasa == null)
            {
                return NotFound();
            }

            return View(rentalCasa);
        }

        // POST: RentalCasa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RentalCasa == null)
            {
                return Problem("Entity set 'inmobiliariaContext.RentalCasa'  is null.");
            }
            var rentalCasa = await _context.RentalCasa.FindAsync(id);
            if (rentalCasa != null)
            {
                _context.RentalCasa.Remove(rentalCasa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalCasaExists(int id)
        {
          return (_context.RentalCasa?.Any(e => e.RentalCasaId == id)).GetValueOrDefault();
        }
    }
}
