using HorasExtra.Domain.Interfaces.Repositories;
using HorasExtra.Domain.Interfaces.Services;
using HorasExtra.Domain.Models;
using HorasExtra.Domain.Validacoes;
using System.Linq;

namespace HorasExtra.Domain.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly LoginValidacao _loginValidacao;

        public LoginService(ILoginRepository loginRepository, LoginValidacao loginValidacao)
        {
            _loginRepository = loginRepository;
            _loginValidacao = loginValidacao;
        }

        public Login Obter(Login request)
        {
            Login response;

            // Validações de e-mail
            _loginValidacao.ValidarLogin(request);
            if (_loginValidacao.Erros.Any())
            {
                response = new Login
                {
                    Erros = _loginValidacao.Erros
                };
                return response;
            }

            // Busca no banco
            response = _loginRepository.Obter(request);

            // Validação se usuário encontrado
            _loginValidacao.ValidarUsuarioLogado(response);
            if (_loginValidacao.Erros.Any())
            {
                response = new Login
                {
                    Erros = _loginValidacao.Erros
                };
                return response;
            }

            // Retorna usuário logado
            return response;
        }
    }
}
