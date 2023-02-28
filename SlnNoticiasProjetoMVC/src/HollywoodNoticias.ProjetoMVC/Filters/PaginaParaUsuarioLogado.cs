using HollywoodNoticias.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace HollywoodNoticias.ProjetoMVC.Filters
{
    public class PaginaParaUsuarioLogado : ActionFilterAttribute 
    {
        public override void OnActionExecuting(ActionExecutingContext context) //esse metodo ele é acessado antes de qualquer coisa no projeto
        {
            //resgata a sessao do usuario
            string sessao = context.HttpContext.Session.GetString("sessaoUsuario");

            //se a sessao for nula, ent nao tem ninguem logado
            if (sessao.IsNullOrEmpty())
            {
                //vai redirecionar para pag inicial
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                //convertendo json em objeto
                UserDTO usuario = JsonConvert.DeserializeObject<UserDTO>(sessao);

                //se por acaso der algum problema na conversao
                if(usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index"} });
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
