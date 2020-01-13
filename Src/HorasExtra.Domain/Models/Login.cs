using System.Collections.Generic;

namespace HorasExtra.Domain.Models
{
    public class Login
    {
        public string Email { get; set; }

        public string Senha { get; set; }

        public string Nome { get; set; }

        public string Perfil { get; set; }

        public List<Erro> Erros { get; set; }
    }
}
