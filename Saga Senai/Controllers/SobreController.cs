using Microsoft.AspNetCore.Mvc;

namespace TarefasApp.Controllers
{
    public class SobreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
