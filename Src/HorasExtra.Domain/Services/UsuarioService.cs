using HorasExtra.Domain.Interfaces.Repositories;
using HorasExtra.Domain.Interfaces.Services;
using HorasExtra.Domain.Models;
using System.Collections.Generic;

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

        public List<Usuario> Listar()
        {
            List<Usuario> response = _usuarioRepository.Listar();
            return response;
        }
    }
}
