using HorasExtra.Application.ViewModels;
using HorasExtra.Domain.Models;
using System.Collections.Generic;

namespace HorasExtra.Application.Mappers
{
    public class UsuarioMapper
    {
        private readonly ErroMapper _erroMapper;

        public UsuarioMapper(ErroMapper erroMapper)
        {
            _erroMapper = erroMapper;
        }

        public Usuario DeViewModelParaModel(UsuarioCadastrarRequestViewModel viewModel)
        {
            Usuario model = new Usuario
            {
                Nome = viewModel.Nome,
                Email = viewModel.Email,
                Senha = viewModel.Senha,
                Perfil = viewModel.Perfil
            };

            return model;
        }

        public List<UsuarioObterResponseViewModel> DeModelParaViewModel(List<Usuario> model)
        {
            List<UsuarioObterResponseViewModel> viewModel = new List<UsuarioObterResponseViewModel>();
            foreach (var item in model)
            {
                viewModel.Add(DeModelParaViewModel(item));
            }

            return viewModel;
        }

        public UsuarioObterResponseViewModel DeModelParaViewModel(Usuario model)
        {
            UsuarioObterResponseViewModel viewModel = new UsuarioObterResponseViewModel
            {
                Nome = model.Nome,
            };

            return viewModel;
        }
    }
}
