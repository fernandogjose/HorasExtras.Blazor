using HorasExtra.Application.ViewModels;
using System.Collections.Generic;

namespace HorasExtra.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        UsuarioCadastrarResponseViewModel Adicionar(UsuarioCadastrarRequestViewModel request);

        List<UsuarioObterResponseViewModel> Listar();
    }
}
