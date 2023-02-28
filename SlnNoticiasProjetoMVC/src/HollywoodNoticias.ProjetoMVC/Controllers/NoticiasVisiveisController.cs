using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HollywoodNoticias.Domain.DTO;
using HollywoodNoticias.ProjetoMVC.Filters;
using HollywoodNoticias.Domain.Contracts.IServices;

namespace HollywoodNoticias.ProjetoMVC.Controllers
{
    [PaginaParaUsuarioLogado]
    public class NoticiasVisiveisController : Controller
    {
        private readonly INoticiaService _service;

        public NoticiasVisiveisController(INoticiaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticia = await _service.GetById(id);

            if (noticia == null)
            {
                return NotFound();
            }

            return View(noticia);
        }
    }
}
