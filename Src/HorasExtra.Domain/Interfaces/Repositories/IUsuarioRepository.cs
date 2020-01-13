using HorasExtra.Domain.Models;
using System.Collections.Generic;

namespace HorasExtra.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario request);

        List<Usuario> Listar();
    }
}
