using HorasExtra.Application.Interfaces;
using HorasExtra.Application.ViewModels;
using HorasExtra.Domain.Interfaces.Services;
using HorasExtra.Domain.Models;

namespace HorasExtra.Application.AppServices
{
    public class LoginAppService : ILoginAppService
    {
        private readonly ILoginService _loginService;

        public LoginAppService(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public LoginResponseViewModel Obter(LoginRequestViewModel request)
        {
            Login requestDomain = new Login
            {
                Email = request.Email,
                Senha = request.Senha
            };

            Login responseDomain = _loginService.Obter(requestDomain);

            LoginResponseViewModel response = new LoginResponseViewModel
            {
                Nome = responseDomain.Nome,
                Email = responseDomain.Email
            };

            return response;
        }
    }
}
