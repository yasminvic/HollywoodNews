using HollywoodNoticias.Domain.Entities;
using HollywoodNoticias.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace HollywoodNoticias.Domain.DTO
{
    public class UserDTO
    {
        [Display(Name = "Código")]
        public int id { get; set; }

        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Login")]
        public string login { get; set; }

        [Display(Name = "Senha")]
        public string senha { get; set; }

        [Display(Name = "Perfil")]
        public PerfilEnum perfil { get; set; }

        [Display(Name = "Criação")]
        public DateTime dateCreated { get; set; }

        public ICollection<ComentarioDTO>? comentarios { get; set; }

        public bool ValidaSenha(string senha)
        {
            return senha.Equals(senha);
        }

        public UserDTO mapToDTO(User user)
        {
            return new UserDTO
            {
                id = user.Id,
                nome = user.Nome,
                email = user.Email,
                login = user.Login,
                senha = user.Senha,
                perfil = user.Perfil,
                dateCreated = user.DateCreated,
            };
        }

        public User mapToEntity()
        {
            return new User
            {
                Id = id,
                Nome = nome,
                Email = email,
                Login = login,
                Senha = senha,
                Perfil = perfil,
                DateCreated = dateCreated,
            };
        }
    }
}
