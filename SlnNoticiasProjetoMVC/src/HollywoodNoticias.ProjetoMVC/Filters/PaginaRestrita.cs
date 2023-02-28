using HollywoodNoticias.Domain.DTO;
using HollywoodNoticias.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace HollywoodNoticias.ProjetoMVC.Filters
{
    public class PaginaRestrita : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessao = context.HttpContext.Session.GetString("sessaoUsuario");

            if (sessao.IsNullOrEmpty())
            {
                context.Result = new RedirectToRouteResult( new RouteValueDictionary { { "controller", "Login"}, { "action", "Index"} });
            }
            else
            {
                UserDTO usuario = JsonConvert.DeserializeObject<UserDTO>(sessao);

                if(usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }

                //ele passou pela verifica de antes, ent tem alguem logado
                //se usuario logado for do padrao, ent ele vai ser jogado pra home
                if(usuario.perfil == PerfilEnum.Padrao)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "Index"} });
                }
            }
        }
    }
}
