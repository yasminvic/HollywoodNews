using HollywoodNoticias.ProjetoMVC.Helper;
using HollywoodNoticias.ProjetoMVC.Models.Entities;
using HollywoodNoticias.ProjetoMVC.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HollywoodNoticias.ProjetoMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _service;
        private readonly ISessao _sessao;

        public LoginController(IUserService service, ISessao sessao)
        {
            _service = service;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            if(_sessao.BuscarSessao() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Create()
        {
            if(_sessao.BuscarSessao() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                User user = _service.FindByLogin(loginModel.Login);

                if (ModelState.IsValid)
                {
                    if(user != null)
                    {
                        if (user.ValidaSenha(loginModel.Senha))
                        {
                            _sessao.CriarSessao(user);
                            return RedirectToAction("Index", "Home");
                        }
                        
                    }
                    
                }

                TempData["MensagemErro"] = $"Ops, Login ou Senha inválidos. Tente novamente!";
                return View("Create");
            }
            catch(Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, algo deu errado. Detalhes do problema: {ex}";
                return View();
            }
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessao();
            return RedirectToAction("Index", "Login");
        }
    }
}
