using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HorasExtra.Application.ViewModels
{
    public class UsuarioCadastrarRequestViewModel
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Perfil")]
        public string Perfil { get; set; }
    }

    public class UsuarioCadastrarResponseViewModel
    {
        List<ErroViewModel> Erros { get; set; }
    }

    public class UsuarioObterResponseViewModel
    {
        public string Nome { get; set; }
    }
}
