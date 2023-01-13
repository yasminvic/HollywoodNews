using HollywoodNoticias.ProjetoMVC.Filters;
using HollywoodNoticias.ProjetoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HollywoodNoticias.ProjetoMVC.Controllers
{
    [PaginaParaUsuarioLogado]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ContextoDatabase _contexto;

        public HomeController(ILogger<HomeController> logger, ContextoDatabase contexto)
        {
            _logger = logger;
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            return View(_contexto.Noticia.Take(2).ToList());
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