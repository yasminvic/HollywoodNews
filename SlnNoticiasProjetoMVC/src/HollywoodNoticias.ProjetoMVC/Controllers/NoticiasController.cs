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
using HollywoodNoticias.ProjetoMVC.Models;

namespace HollywoodNoticias.ProjetoMVC.Controllers
{
    [PaginaRestrita]
    public class NoticiasController : Controller
    {
        private readonly INoticiaService _service;
        private readonly ICategoriaService _catService;

        public NoticiasController(INoticiaService service, ICategoriaService catService)
        {
            _service = service;
            _catService = catService;   
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

        public async Task<IActionResult> Create()
        {
            ViewData["categoriaId"] = new SelectList( await _catService.GetAll(), "id", "nome", "Selecione...");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("id,categoriaId,titulo,descricao,texto,enderecoImagem")] NoticiaDTO noticia)
        {
            if (ModelState.IsValid)
            {
                await _service.Save(noticia);
                TempData["MensagemSucesso"] = "Registro salvo com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["categoriaId"] = new SelectList(await _catService.GetAll(), "id", "nome", "Selecione...");
            TempData["MensagemErro"] = "Erro ao salvar registro!";
            return View(noticia);
        }

        public async Task<IActionResult> Edit(int id)
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
            ViewData["categoriaId"] = new SelectList(await _catService.GetAll(), "id", "nome", "Selecione...");
            return View(noticia);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("id,categoriaId,titulo,descricao,texto,enderecoImagem")] NoticiaDTO noticia)
        {
            if (id != noticia.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.Save(noticia);
                TempData["MensagemSucesso"] = "Registro alterado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["categoriaId"] = new SelectList(await _catService.GetAll(), "id", "nome", "Selecione...");
            TempData["MensagemErro"] = "Erro ao alterar registro!";
            return View(noticia);
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
