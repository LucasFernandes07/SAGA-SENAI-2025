using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ald_controls.Data;
using ald_controls.Models;

namespace ald_controls.Controllers
{
    public class RegistroEpisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistroEpisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegistroEpis
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RegistrosEpi.Include(r => r.Colaborador).Include(r => r.Epi);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RegistroEpis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroEpi = await _context.RegistrosEpi
                .Include(r => r.Colaborador)
                .Include(r => r.Epi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroEpi == null)
            {
                return NotFound();
            }

            return View(registroEpi);
        }

        // GET: RegistroEpis/Create
        public IActionResult Create()
        {
            ViewData["ColaboradorId"] = new SelectList(_context.Colaboradores, "Id", "Nome");
            ViewData["EpiId"] = new SelectList(_context.Epis, "Id", "Id");
            return View();
        }

        // POST: RegistroEpis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ColaboradorId,EpiId,DataRegistro,Pontos")] RegistroEpi registroEpi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroEpi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaboradores, "Id", "Nome", registroEpi.ColaboradorId);
            ViewData["EpiId"] = new SelectList(_context.Epis, "Id", "Id", registroEpi.EpiId);
            return View(registroEpi);
        }

        // GET: RegistroEpis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroEpi = await _context.RegistrosEpi.FindAsync(id);
            if (registroEpi == null)
            {
                return NotFound();
            }
            ViewData["ColaboradorId"] = new SelectList(_context.Colaboradores, "Id", "Nome", registroEpi.ColaboradorId);
            ViewData["EpiId"] = new SelectList(_context.Epis, "Id", "Id", registroEpi.EpiId);
            return View(registroEpi);
        }

        // POST: RegistroEpis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ColaboradorId,EpiId,DataRegistro,Pontos")] RegistroEpi registroEpi)
        {
            if (id != registroEpi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroEpi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroEpiExists(registroEpi.Id))
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
            ViewData["ColaboradorId"] = new SelectList(_context.Colaboradores, "Id", "Nome", registroEpi.ColaboradorId);
            ViewData["EpiId"] = new SelectList(_context.Epis, "Id", "Id", registroEpi.EpiId);
            return View(registroEpi);
        }

        // GET: RegistroEpis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroEpi = await _context.RegistrosEpi
                .Include(r => r.Colaborador)
                .Include(r => r.Epi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroEpi == null)
            {
                return NotFound();
            }

            return View(registroEpi);
        }

        // POST: RegistroEpis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroEpi = await _context.RegistrosEpi.FindAsync(id);
            if (registroEpi != null)
            {
                _context.RegistrosEpi.Remove(registroEpi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroEpiExists(int id)
        {
            return _context.RegistrosEpi.Any(e => e.Id == id);
        }
    }
}
