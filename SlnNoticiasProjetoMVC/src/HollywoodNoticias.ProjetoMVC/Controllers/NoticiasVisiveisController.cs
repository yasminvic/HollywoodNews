using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HollywoodNoticias.ProjetoMVC.Models;
using HollywoodNoticias.ProjetoMVC.Models.Entities;
using HollywoodNoticias.ProjetoMVC.Filters;

namespace HollywoodNoticias.ProjetoMVC.Controllers
{
    [PaginaParaUsuarioLogado]
    public class NoticiasVisiveisController : Controller
    {
        private readonly ContextoDatabase _context;

        public NoticiasVisiveisController(ContextoDatabase context)
        {
            _context = context;
        }

        // GET: NoticiasVisiveis
        public async Task<IActionResult> Index()
        {
            var contextoDatabase = _context.Noticia.Include(n => n.Categoria);
            return View(await contextoDatabase.ToListAsync());
        }

        // GET: NoticiasVisiveis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Noticia == null)
            {
                return NotFound();
            }

            var noticia = await _context.Noticia
                .Include(n => n.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noticia == null)
            {
                return NotFound();
            }

            return View(noticia);
        }
    }
}
