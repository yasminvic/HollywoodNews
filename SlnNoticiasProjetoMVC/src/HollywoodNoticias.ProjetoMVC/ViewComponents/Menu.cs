using HollywoodNoticias.ProjetoMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace HollywoodNoticias.ProjetoMVC.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //resgantando a sessao do user
            string sessao = HttpContext.Session.GetString("sessaoUsuario");

            //verificando se tem alguem logado
            if (sessao.IsNullOrEmpty())
            {
                return null;
            }

            //convertendo json em objeto
            User usuario = JsonConvert.DeserializeObject<User>(sessao);

            return View(usuario);
        }
    }
}
