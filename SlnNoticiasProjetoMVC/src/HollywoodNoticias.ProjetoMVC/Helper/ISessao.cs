using HollywoodNoticias.ProjetoMVC.Models.Entities;

namespace HollywoodNoticias.ProjetoMVC.Helper
{
    public interface ISessao
    {
        User BuscarSessao();
        void CriarSessao(User user);
        void RemoverSessao();
    }
}
