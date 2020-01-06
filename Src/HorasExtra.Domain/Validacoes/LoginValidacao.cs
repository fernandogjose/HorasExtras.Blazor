using HorasExtra.Domain.Models;
using System.Collections.Generic;

namespace HorasExtra.Domain.Validacoes
{
    public class LoginValidacao
    {
        public List<Erro> Erros { get; private set; }

        public LoginValidacao()
        {
            Erros = new List<Erro>();
        }

        private void LimpaErros()
        {
            Erros = new List<Erro>(0);
        }

        private void ValidarEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                Erros.Add(new Erro
                {
                    Codigo = 400,
                    Descricao = "E-mail é obrigatório"
                });
            }

            string[] emailSplit = email.Split('@');
            if (emailSplit.Length != 2 || emailSplit[1] != "avivatec.com.br")
            {
                Erros.Add(new Erro
                {
                    Codigo = 400,
                    Descricao = "E-mail inválido"
                });
            }
        }

        private void ValidarSenha(string senha)
        {
            if (string.IsNullOrEmpty(senha))
            {
                Erros.Add(new Erro
                {
                    Codigo = 400,
                    Descricao = "Senha é obrigatório"
                });
            }
        }

        public void ValidarLogin(Login request)
        {
            LimpaErros();
            ValidarEmail(request.Email);
            ValidarSenha(request.Senha);
        }

        public void ValidarUsuarioLogado(Login request)
        {
            LimpaErros();
            if (request == null || string.IsNullOrEmpty(request.Nome))
            {
                Erros.Add(new Erro
                {
                    Codigo = 404,
                    Descricao = "E-mail ou Senha não encontrado"
                });
            }
        }
    }
}
