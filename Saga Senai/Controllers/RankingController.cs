using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TarefasApp.Models;
using TarefasApp.Data;

namespace TarefasApp.Controllers
{
    public class RankingController : Controller
    {
        private readonly AppDbContext _context;

        public RankingController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ranking = _context.Colaboradores
                .Select(c => new RankingViewModel
                {
                    Nome = c.Nome,
                    Setor = c.Setor,
                    PontosTotais = c.Pontos // Ajuste se a soma vier de outra tabela
                })
                .OrderByDescending(r => r.PontosTotais)
                .ToList();

            return View(ranking);
        }
    }

    public class RankingViewModel
    {
        public string Nome { get; set; }
        public string Setor { get; set; }
        public int PontosTotais { get; set; }
    }
}
