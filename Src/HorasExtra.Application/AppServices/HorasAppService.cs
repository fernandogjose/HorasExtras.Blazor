using HorasExtra.Application.Interfaces;
using HorasExtra.Application.Mappers;
using HorasExtra.Application.ViewModels;
using HorasExtra.Domain.Interfaces.Services;
using HorasExtra.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HorasExtra.Application.AppServices
{
    public class HorasAppService : IHorasAppService
    {
        private readonly IHorasService _horasService;
        private readonly HorasMapper _horasMapper;

        public HorasAppService(IHorasService horasService, HorasMapper horasMapper)
        {
            _horasService = horasService;
            _horasMapper = horasMapper;
        }

        public HorasCadastrarResponseViewModel Adicionar(HorasCadastrarRequestViewModel request)
        {
            Horas requestDomain = _horasMapper.DeViewModelParaModel(request);
            _horasService.Adicionar(requestDomain);
            HorasCadastrarResponseViewModel response = new HorasCadastrarResponseViewModel();
            return response;
        }

        public HorasCadastrarResponseViewModel Deletar(HorasCadastrarRequestViewModel request)
        {
            throw new NotImplementedException();
        }

        public HorasCadastrarResponseViewModel Editar(HorasCadastrarRequestViewModel request)
        {
            Horas requestModel = _horasMapper.DeViewModelParaModel(request);
            _horasService.Editar(requestModel);
            HorasCadastrarResponseViewModel response = new HorasCadastrarResponseViewModel();
            return response;
        }

        public HorasObterResponseViewModel Obter(string id)
        {
            Horas responseModel = _horasService.Obter(id);
            HorasObterResponseViewModel response = _horasMapper.DeModelParaViewModel(responseModel);
            return response;
        }

        public List<HorasObterResponseViewModel> Listar(HorasListarRequestViewModel request)
        {
            Horas requestModel = new Horas { Desenvolvedor = request.Desenvolvedor };
            List<Horas> responseModel = _horasService.Listar(requestModel);
            List<HorasObterResponseViewModel> response = _horasMapper.DeModelParaViewModel(responseModel);

            return response;
        }
    }
}
