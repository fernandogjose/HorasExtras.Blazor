using HorasExtra.Application.Interfaces;
using HorasExtra.Application.ViewModels;
using HorasExtra.Domain.Interfaces.Services;
using HorasExtra.Domain.Models;

namespace HorasExtra.Application.AppServices
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public UsuarioCadastrarResponseViewModel Adicionar(UsuarioCadastrarRequestViewModel request)
        {
            Usuario requestDomain = new Usuario
            {
                Nome = request.Nome,
                Email = request.Email,
                Senha = request.Senha
            };

            _usuarioService.Adicionar(requestDomain);

            UsuarioCadastrarResponseViewModel response = new UsuarioCadastrarResponseViewModel();
            return response;
        }
    }
}
