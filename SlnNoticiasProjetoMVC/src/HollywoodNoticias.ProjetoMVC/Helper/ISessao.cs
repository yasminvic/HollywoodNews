using HollywoodNoticias.Domain.DTO;

namespace HollywoodNoticias.ProjetoMVC.Helper
{
    public interface ISessao
    {
        UserDTO BuscarSessao();
        void CriarSessao(UserDTO user);
        void RemoverSessao();
    }
}
