using HorasExtra.Application.Interfaces;
using HorasExtra.Application.ViewModels;
using HorasExtra.Blazor.Providers;
using Microsoft.AspNetCore.Components.Authorization;

namespace HorasExtra.Blazor.PagesServices
{
    public class LoginPageService
    {
        private readonly ILoginAppService _loginAppService;
        private readonly CustomAuthenticationStateProvider _customAuthenticationStateProvider;

        public LoginPageService(ILoginAppService loginAppService, AuthenticationStateProvider authenticationStateProvider)
        {
            _loginAppService = loginAppService;
            _customAuthenticationStateProvider = authenticationStateProvider as CustomAuthenticationStateProvider;
        }

        public LoginResponseViewModel LogIn(LoginRequestViewModel request)
        {
            LoginResponseViewModel response = _loginAppService.Obter(request);
            if (response != null && !string.IsNullOrEmpty(response.Nome))
            {
                _customAuthenticationStateProvider.LogIn(response);
            }

            return response;
        }
    }
}
