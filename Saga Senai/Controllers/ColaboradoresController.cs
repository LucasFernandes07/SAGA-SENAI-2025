using Microsoft.AspNetCore.Mvc;
using TarefasApp.Models;
using TarefasApp.Data;
using System.Linq;

namespace TarefasApp.Controllers
{
    public class ColaboradoresController : Controller
    {
        private readonly AppDbContext _context;

        public ColaboradoresController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var colaboradores = _context.Colaboradores.OrderByDescending(c => c.Pontos).ToList();
            return View(colaboradores);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                _context.Colaboradores.Add(colaborador);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colaborador);
        }
    }
}
