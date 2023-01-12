using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HollywoodNoticias.ProjetoMVC.Models;
using HollywoodNoticias.ProjetoMVC.Models.Entities;
using HollywoodNoticias.ProjetoMVC.Service.Interface;
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
        public IActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User usuario = _service.Cadastrar(user);
                    _sessao.CriarSessao(user);
                }
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
