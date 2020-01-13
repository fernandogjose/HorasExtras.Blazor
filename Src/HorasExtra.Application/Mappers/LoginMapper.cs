using HorasExtra.Application.ViewModels;
using HorasExtra.Domain.Models;

namespace HorasExtra.Application.Mappers
{
    public class LoginMapper
    {
        private readonly ErroMapper _erroMapper;

        public LoginMapper(ErroMapper erroMapper)
        {
            _erroMapper = erroMapper;
        }

        public Login DeViewModelParaModel(LoginRequestViewModel viewModel)
        {
            Login model = new Login
            {
                Email = viewModel.Email,
                Senha = viewModel.Senha
            };

            return model;
        }

        public LoginResponseViewModel DeModelParaViewModel(Login model)
        {
            LoginResponseViewModel viewModel = new LoginResponseViewModel
            {
                Nome = model.Nome,
                Email = model.Email,
                Perfil = model.Perfil,
                Erros = _erroMapper.DeModelParaViewModel(model.Erros)
            };

            return viewModel;
        }
    }
}
