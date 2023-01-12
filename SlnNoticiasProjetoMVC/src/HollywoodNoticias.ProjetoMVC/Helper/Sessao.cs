using HollywoodNoticias.ProjetoMVC.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace HollywoodNoticias.ProjetoMVC.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Sessao(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public User BuscarSessao()
        {
            string sessao = _httpContextAccessor.HttpContext.Session.GetString("sessaoUsuario");

            if (sessao.IsNullOrEmpty())
            {
                return null;
            }

            return JsonConvert.DeserializeObject<User>(sessao);
        }

        public void CriarSessao(User user)
        {
            //convertendo pra json
            string userConvertido = JsonConvert.SerializeObject(user);

            _httpContextAccessor.HttpContext.Session.SetString("sessaoUsuario", userConvertido);
                                                                //key           //value
        }

        public void RemoverSessao()
        {
            _httpContextAccessor.HttpContext.Session.Remove("sessaoUsuario");
        }
    }
}
