using HollywoodNoticias.ProjetoMVC.Filters;
using HollywoodNoticias.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HollywoodNoticias.Domain.Contracts.IServices;
using HollywoodNoticias.ProjetoMVC.Models;

namespace HollywoodNoticias.ProjetoMVC.Controllers
{
    [PaginaParaUsuarioLogado]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INoticiaService _noticiaService;

        public HomeController(ILogger<HomeController> logger, INoticiaService service)
        {
            _logger = logger;
            _noticiaService = service;
        }

        public async Task<IActionResult> Index()
        {
            int size = 7;

            var listall = await _noticiaService.GetAll();

            List<NoticiaDTO> ultimosRegistros = new List<NoticiaDTO>(size);

            if (listall.Count >= 7)
            {
                for (int i = listall.Count - 1; i > listall.Count - 8; i--)
                {
                    ultimosRegistros.Add(listall[i]);
                }
            }
            
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