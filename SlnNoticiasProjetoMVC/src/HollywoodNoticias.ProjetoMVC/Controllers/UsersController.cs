using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HollywoodNoticias.Domain.DTO;
using HollywoodNoticias.Domain.Contracts.IServices;
using HollywoodNoticias.ProjetoMVC.Helper;
using HollywoodNoticias.ProjetoMVC.Filters;

namespace HollywoodNoticias.ProjetoMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _service;
        private readonly ISessao _sessao;

        public UsersController(IUserService service, ISessao sessao)
        {
            _service = service;
            _sessao = sessao;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDTO user)
        {
            user.dateCreated = DateTime.Now;
            if (ModelState.IsValid)
            {
                await _service.Save(user);
                _sessao.CriarSessao(user);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Login");

        }
    }
}
