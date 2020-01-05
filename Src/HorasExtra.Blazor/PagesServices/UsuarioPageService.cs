using HorasExtra.Application.Interfaces;
using HorasExtra.Application.ViewModels;

namespace HorasExtra.Blazor.PagesServices
{
    public class UsuarioPageService
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioPageService(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        public UsuarioCadastrarResponseViewModel Adicionar(UsuarioCadastrarRequestViewModel request)
        {
            UsuarioCadastrarResponseViewModel response = _usuarioAppService.Adicionar(request);
            return response;
        }
    }
}
