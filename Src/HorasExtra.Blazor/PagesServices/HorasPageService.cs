using HorasExtra.Application.Interfaces;
using HorasExtra.Application.ViewModels;
using System.Collections.Generic;

namespace HorasExtra.Blazor.PagesServices
{
    public class HorasPageService
    {
        private readonly IHorasAppService _horasAppService;

        public HorasPageService(IHorasAppService horasAppService)
        {
            _horasAppService = horasAppService;
        }

        public HorasObterResponseViewModel Obter(string id)
        {
            HorasObterResponseViewModel response = _horasAppService.Obter(id);
            return response;
        }

        public List<HorasListarResponseViewModel> Listar(HorasListarRequestViewModel request)
        {
            List<HorasListarResponseViewModel> response = _horasAppService.Listar(request);
            return response;
        }

        public HorasCadastrarResponseViewModel Adicionar(HorasCadastrarRequestViewModel request)
        {
            HorasCadastrarResponseViewModel response = _horasAppService.Adicionar(request);
            return response;
        }
    }
}
