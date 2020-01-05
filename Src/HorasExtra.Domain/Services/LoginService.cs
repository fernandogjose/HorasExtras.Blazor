using HorasExtra.Domain.Interfaces.Repositories;
using HorasExtra.Domain.Interfaces.Services;
using HorasExtra.Domain.Models;

namespace HorasExtra.Domain.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public Login Obter(Login request)
        {
            Login response = _loginRepository.Obter(request);
            return response;
        }
    }
}
