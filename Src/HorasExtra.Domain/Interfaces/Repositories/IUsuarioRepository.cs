using HorasExtra.Domain.Models;

namespace HorasExtra.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario request);
    }
}
