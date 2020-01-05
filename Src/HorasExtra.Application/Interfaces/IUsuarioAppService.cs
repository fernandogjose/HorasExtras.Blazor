using HorasExtra.Application.ViewModels;

namespace HorasExtra.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        UsuarioCadastrarResponseViewModel Adicionar(UsuarioCadastrarRequestViewModel request);
    }
}
