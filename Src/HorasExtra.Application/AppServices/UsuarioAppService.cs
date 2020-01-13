using HorasExtra.Application.Interfaces;
using HorasExtra.Application.Mappers;
using HorasExtra.Application.ViewModels;
using HorasExtra.Domain.Interfaces.Services;
using HorasExtra.Domain.Models;
using System.Collections.Generic;

namespace HorasExtra.Application.AppServices
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly UsuarioMapper _usuarioMapper;

        public UsuarioAppService(IUsuarioService usuarioService, UsuarioMapper usuarioMapper)
        {
            _usuarioService = usuarioService;
            _usuarioMapper = usuarioMapper;
        }

        public UsuarioCadastrarResponseViewModel Adicionar(UsuarioCadastrarRequestViewModel request)
        {
            Usuario requestDomain = _usuarioMapper.DeViewModelParaModel(request);
            _usuarioService.Adicionar(requestDomain);
            UsuarioCadastrarResponseViewModel response = new UsuarioCadastrarResponseViewModel();
            return response;
        }

        public List<UsuarioObterResponseViewModel> Listar()
        {
            List<Usuario> responseModel = _usuarioService.Listar();
            List<UsuarioObterResponseViewModel> response = _usuarioMapper.DeModelParaViewModel(responseModel);
            return response;
        }
    }
}
