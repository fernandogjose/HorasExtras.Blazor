using HorasExtra.Application.Interfaces;
using HorasExtra.Application.Mappers;
using HorasExtra.Application.ViewModels;
using HorasExtra.Domain.Interfaces.Services;
using HorasExtra.Domain.Models;

namespace HorasExtra.Application.AppServices
{
    public class LoginAppService : ILoginAppService
    {
        private readonly ILoginService _loginService;
        private readonly LoginMapper _loginMapper;

        public LoginAppService(ILoginService loginService, LoginMapper loginMapper)
        {
            _loginService = loginService;
            _loginMapper = loginMapper;
        }

        public LoginResponseViewModel Obter(LoginRequestViewModel request)
        {
            Login requestModel = _loginMapper.DeViewModelParaModel(request);
            Login responseModel = _loginService.Obter(requestModel);
            LoginResponseViewModel response = _loginMapper.DeModelParaViewModel(responseModel);

            return response;
        }
    }
}
