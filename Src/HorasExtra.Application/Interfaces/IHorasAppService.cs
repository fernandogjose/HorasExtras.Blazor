using HorasExtra.Application.ViewModels;
using System.Collections.Generic;

namespace HorasExtra.Application.Interfaces
{
    public interface IHorasAppService
    {
        HorasObterResponseViewModel Obter(string id);

        List<HorasListarResponseViewModel> Listar(HorasListarRequestViewModel request);

        HorasCadastrarResponseViewModel Adicionar(HorasCadastrarRequestViewModel request);

        HorasCadastrarResponseViewModel Editar(HorasCadastrarRequestViewModel request);

        HorasCadastrarResponseViewModel Deletar(HorasCadastrarRequestViewModel request);
    }
}
