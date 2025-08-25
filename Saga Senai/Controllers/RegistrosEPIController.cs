using Microsoft.AspNetCore.Mvc;
using TarefasApp.Models;
using TarefasApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TarefasApp.Controllers
{
    public class RegistrosEPIController : Controller
    {
        private readonly AppDbContext _context;

        public RegistrosEPIController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var registros = _context.RegistrosEPI.Include(r => r.Colaborador).OrderByDescending(r => r.DataRegistro).ToList();
            return View(registros);
        }

        public IActionResult Create()
        {
            ViewBag.Colaboradores = _context.Colaboradores.ToList();
            ViewBag.EPIs = new[] { "Luva", "Máscara", "Uniforme", "Óculos", "Botina" };
            return View();
        }

        [HttpPost]
        public IActionResult Create(RegistroEPI registro)
        {
            if (ModelState.IsValid)
            {
                var colaborador = _context.Colaboradores.Find(registro.ColaboradorId);
                if (colaborador != null)
                {
                    colaborador.Pontos += registro.Pontos;
                    _context.RegistrosEPI.Add(registro);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("ColaboradorId", "Colaborador não encontrado.");
            }
            ViewBag.Colaboradores = _context.Colaboradores.ToList();
            ViewBag.EPIs = new[] { "Luva", "Máscara", "Uniforme", "Óculos", "Botina" };
            return View(registro);
        }
    }
}
