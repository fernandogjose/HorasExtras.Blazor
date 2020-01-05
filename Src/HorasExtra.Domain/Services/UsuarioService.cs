using HorasExtra.Domain.Interfaces.Repositories;
using HorasExtra.Domain.Interfaces.Services;
using HorasExtra.Domain.Models;

namespace HorasExtra.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void Adicionar(Usuario request)
        {
            _usuarioRepository.Adicionar(request);
        }
    }
}
