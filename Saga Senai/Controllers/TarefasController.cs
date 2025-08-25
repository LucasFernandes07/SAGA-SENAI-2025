using Microsoft.AspNetCore.Mvc;
using TarefasApp.Models;
using TarefasApp.Data;
using Microsoft.AspNetCore.Authorization;

namespace TarefasApp.Controllers
{
        [Authorize]
        public class TarefasController : Controller
    {
        private readonly AppDbContext _context;

        public TarefasController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string filtro)
        {
            var tarefas = string.IsNullOrEmpty(filtro)
                ? _context.Tarefas.ToList()
                : _context.Tarefas.Where(t => t.Titulo.Contains(filtro)).ToList();
            return View(tarefas);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Edit(Tarefa tarefa)
        {
            // Corrige o checkbox de concluída: se não vier no POST, define como false
            tarefa.Concluida = Request.Form["Concluida"] == "true";
            _context.Tarefas.Update(tarefa);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ToggleConcluida(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa != null)
            {
                tarefa.Concluida = !tarefa.Concluida;
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
                return NotFound();
            return View(tarefa);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}