using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationPrueba.Data;
using WebApplicationPrueba.Entities;

namespace WebApplicationPrueba.Controllers
{
    public class HijoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HijoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hijoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hijos.ToListAsync());
        }

        // GET: Hijoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hijo = await _context.Hijos
                .FirstOrDefaultAsync(m => m.HijoId == id);
            if (hijo == null)
            {
                return NotFound();
            }

            return View(hijo);
        }

        // GET: Hijoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hijoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HijoId,Nombre,Apellido,Nacimiento")] Hijo hijo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hijo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hijo);
        }

        // GET: Hijoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hijo = await _context.Hijos.FindAsync(id);
            if (hijo == null)
            {
                return NotFound();
            }
            return View(hijo);
        }

        // POST: Hijoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HijoId,Nombre,Apellido,Nacimiento")] Hijo hijo)
        {
            if (id != hijo.HijoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hijo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HijoExists(hijo.HijoId))
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
            return View(hijo);
        }

        // GET: Hijoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hijo = await _context.Hijos
                .FirstOrDefaultAsync(m => m.HijoId == id);
            if (hijo == null)
            {
                return NotFound();
            }

            return View(hijo);
        }

        // POST: Hijoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hijo = await _context.Hijos.FindAsync(id);
            _context.Hijos.Remove(hijo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HijoExists(int id)
        {
            return _context.Hijos.Any(e => e.HijoId == id);
        }
    }
}
