using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HorasExtra.Application.ViewModels
{
    public class LoginRequestViewModel
    {
        [Required(ErrorMessage = "E-mail é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")]
        public string Senha { get; set; }
    }

    public class LoginResponseViewModel
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Perfil { get; set; }

        public List<ErroViewModel> Erros { get; set; }
    }
}
