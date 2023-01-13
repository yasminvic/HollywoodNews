using HollywoodNoticias.ProjetoMVC.Filters;
using HollywoodNoticias.ProjetoMVC.Models;
using HollywoodNoticias.ProjetoMVC.Models.Entities;
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
            var ultimosRegistros = _contexto.Noticia.OrderByDescending(n => n.Id).Take(7).ToList();
            return View(ultimosRegistros);
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