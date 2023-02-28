using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HollywoodNoticias.ProjetoMVC.Models;
using HollywoodNoticias.Domain.DTO;
using HollywoodNoticias.ProjetoMVC.Filters;
using HollywoodNoticias.Domain.Contracts.IServices;

namespace HollywoodNoticias.ProjetoMVC.Controllers
{
    [PaginaRestrita]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _service;

        public CategoriasController(ICategoriaService service)
        {
            _service = service;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
              return View(await _service.GetAll());
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _service.GetById(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("id,nome")] CategoriaDTO categoria)
        {
            if (ModelState.IsValid)
            {
                _service.Save(categoria);
                TempData["MensagemSucesso"] = "Registro salvo com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            TempData["MensagemErro"] = "Erro ao salvar registro!";
            return View(categoria);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _service.GetById(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome")] CategoriaDTO categoria)
        {
            if (id != categoria.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _service.Save(categoria);
                TempData["MensagemSucesso"] = "Registro alterado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            TempData["MensagemErro"] = "Erro ao alterar registro!";
            return View(categoria);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int? id)
        {
            var retDel = new ReturnJsonDelete
            {
                status = "Success",
                code = "200"
            };
            try
            {
                if (await _service.Delete(id ?? 0) <= 0)
                {
                    retDel = new ReturnJsonDelete
                    {
                        status = "Error",
                        code = "400"
                    };
                }
            }
            catch (Exception ex)
            {
                retDel = new ReturnJsonDelete
                {
                    status = ex.Message,
                    code = "500"
                };
            }
            return Json(retDel);
        }
    }
}
