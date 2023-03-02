using Microsoft.AspNetCore.Mvc;
using SimeoneCRUD.Models;
using System.Diagnostics;

namespace SimeoneCRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Allievi()
        {
            return View();
        }
        public IActionResult Professori()
        {
            return View();
        }
        public IActionResult Lezioni()
        {
            return View();
        }
        public IActionResult Allievi_Lezioni()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}