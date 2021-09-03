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
    public class ConyugesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConyugesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Conyuges
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Conyuges.Include(c => c.Empleado);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Conyuges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conyuge = await _context.Conyuges
                .Include(c => c.Empleado)
                .FirstOrDefaultAsync(m => m.ConyugeId == id);
            if (conyuge == null)
            {
                return NotFound();
            }

            return View(conyuge);
        }

        // GET: Conyuges/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "EmpleadoId");
            return View();
        }

        // POST: Conyuges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConyugeId,Cedula,Nombre,Apellido,EmpleadoId")] Conyuge conyuge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conyuge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "EmpleadoId", conyuge.EmpleadoId);
            return View(conyuge);
        }

        // GET: Conyuges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conyuge = await _context.Conyuges.FindAsync(id);
            if (conyuge == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "EmpleadoId", conyuge.EmpleadoId);
            return View(conyuge);
        }

        // POST: Conyuges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConyugeId,Cedula,Nombre,Apellido,EmpleadoId")] Conyuge conyuge)
        {
            if (id != conyuge.ConyugeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conyuge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConyugeExists(conyuge.ConyugeId))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "EmpleadoId", "EmpleadoId", conyuge.EmpleadoId);
            return View(conyuge);
        }

        // GET: Conyuges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conyuge = await _context.Conyuges
                .Include(c => c.Empleado)
                .FirstOrDefaultAsync(m => m.ConyugeId == id);
            if (conyuge == null)
            {
                return NotFound();
            }

            return View(conyuge);
        }

        // POST: Conyuges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conyuge = await _context.Conyuges.FindAsync(id);
            _context.Conyuges.Remove(conyuge);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConyugeExists(int id)
        {
            return _context.Conyuges.Any(e => e.ConyugeId == id);
        }
    }
}
