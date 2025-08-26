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
    public class EpisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EpisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Epis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Epis.ToListAsync());
        }

        // GET: Epis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epi = await _context.Epis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (epi == null)
            {
                return NotFound();
            }

            return View(epi);
        }

        // GET: Epis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Epis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao")] Epi epi)
        {
            if (ModelState.IsValid)
            {
                // Adiciona descrição padrão para capacete e luva
                if (epi.Nome.ToLower().Contains("capacete"))
                {
                    epi.Descricao = "O capacete é utilizado para proteger a cabeça contra impactos, quedas de objetos e outros riscos no ambiente de trabalho.";
                }
                else if (epi.Nome.ToLower().Contains("luva"))
                {
                    epi.Descricao = "A luva é utilizada para proteger as mãos contra agentes químicos, cortes, perfurações e outros riscos ocupacionais.";
                }
                _context.Add(epi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(epi);
        }

        // GET: Epis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epi = await _context.Epis.FindAsync(id);
            if (epi == null)
            {
                return NotFound();
            }
            return View(epi);
        }

        // POST: Epis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao")] Epi epi)
        {
            if (id != epi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(epi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EpiExists(epi.Id))
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
            return View(epi);
        }

        // GET: Epis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epi = await _context.Epis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (epi == null)
            {
                return NotFound();
            }

            return View(epi);
        }

        // POST: Epis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var epi = await _context.Epis.FindAsync(id);
            if (epi != null)
            {
                _context.Epis.Remove(epi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EpiExists(int id)
        {
            return _context.Epis.Any(e => e.Id == id);
        }
    }
}
