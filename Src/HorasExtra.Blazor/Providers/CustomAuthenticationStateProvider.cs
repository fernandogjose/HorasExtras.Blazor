using Blazored.SessionStorage;
using HorasExtra.Application.ViewModels;
using HorasExtra.Blazor.Helpers;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HorasExtra.Blazor.Providers
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorageService;
        private readonly CryptHelper _cryptHelper;

        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorageService, CryptHelper cryptHelper)
        {
            _sessionStorageService = sessionStorageService;
            _cryptHelper = cryptHelper;
        }

        private Task<ClaimsPrincipal> GetNewClaim()
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return Task.FromResult(claimsPrincipal);
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                // Cria as váriaveis dos claims
                ClaimsIdentity claimsIdentity;
                ClaimsPrincipal claimsPrincipal;

                // Busca do session storage o objeto criptografado
                string usuarioLogadoCriptografado = await _sessionStorageService.GetItemAsync<string>("ulc");
                string usuarioEmailCriptografado = await _sessionStorageService.GetItemAsync<string>("uec");

                // Se não encontrou volta o usuário não logado
                if (string.IsNullOrEmpty(usuarioLogadoCriptografado) || string.IsNullOrEmpty(usuarioEmailCriptografado))
                {
                    return await Task.FromResult(new AuthenticationState(await GetNewClaim()));
                }

                // Descriptografa o objeto do usuário logado e verifica se o usuário existe
                string usuarioLogadoJson = _cryptHelper.Decrypt(usuarioLogadoCriptografado);
                LoginResponseViewModel usuarioLogado = JsonConvert.DeserializeObject<LoginResponseViewModel>(usuarioLogadoJson);
                if (usuarioLogado == null)
                {
                    return await Task.FromResult(new AuthenticationState(await GetNewClaim()));
                }

                // Verifica se o usuário logado é o mesmo do e-mail
                string usuarioEmail = _cryptHelper.Decrypt(usuarioEmailCriptografado);
                if (usuarioLogado.Email != usuarioEmail)
                {
                    return await Task.FromResult(new AuthenticationState(await GetNewClaim()));
                }

                // Usuário logado e objeto está válido
                claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, usuarioLogado.Nome) }, "HorasExtrasAuth");
                claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new AuthenticationState(await GetNewClaim()));
            }
        }

        public void LogIn(LoginResponseViewModel request)
        {
            // Criptografa o objeto do usuário logado e o email
            string usuarioLogadoJson = JsonConvert.SerializeObject(request);
            string usuarioLogadoCriptografado = _cryptHelper.Encrypt(usuarioLogadoJson);
            string usuarioEmailCriptografado = _cryptHelper.Encrypt(request.Email);

            // Adiciona na session storage
            _sessionStorageService.SetItemAsync("ulc", usuarioLogadoCriptografado);
            _sessionStorageService.SetItemAsync("uec", usuarioEmailCriptografado);

            // Cria o Claim
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, request.Nome) }, "HorasExtrasAuth");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async void LogOut()
        {
            await _sessionStorageService.RemoveItemAsync("ulc");
            await _sessionStorageService.RemoveItemAsync("uec");

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(await GetNewClaim())));
        }
    }
}
