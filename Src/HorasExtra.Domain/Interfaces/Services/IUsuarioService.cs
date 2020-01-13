using HorasExtra.Domain.Models;
using System.Collections.Generic;

namespace HorasExtra.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        void Adicionar(Usuario request);

        List<Usuario> Listar();
    }
}
