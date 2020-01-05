using HorasExtra.Application.Interfaces;
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

        public HorasAppService(IHorasService horasService)
        {
            _horasService = horasService;
        }

        public HorasCadastrarResponseViewModel Adicionar(HorasCadastrarRequestViewModel request)
        {
            Horas requestDomain = new Horas
            {
                Desenvolvedor = request.Desenvolvedor,
                Data = request.Data,
                HoraInicio = request.HoraInicio,
                HoraFim = request.HoraFim
            };

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
            throw new NotImplementedException();
        }

        public HorasObterResponseViewModel Obter(string id)
        {
            Horas responseDomain = _horasService.Obter(id);
            HorasObterResponseViewModel response = new HorasObterResponseViewModel();
            response.Id = responseDomain.Id;
            response.Desenvolvedor = responseDomain.Desenvolvedor;
            response.Data = responseDomain.Data;
            response.HoraInicio = responseDomain.HoraInicio;
            response.HoraFim = responseDomain.HoraFim;

            return response;
        }

        public List<HorasListarResponseViewModel> Listar(HorasListarRequestViewModel request)
        {
            Horas requestDomain = new Horas { Desenvolvedor = request.Desenvolvedor };
            List<Horas> responseDomain = _horasService.Listar(requestDomain);
            List<HorasListarResponseViewModel> response = new List<HorasListarResponseViewModel>(0);
            foreach (var horas in responseDomain.OrderBy(x => x.Data))
            {
                HorasListarResponseViewModel horasListar = new HorasListarResponseViewModel();
                horasListar.Id = horas.Id;
                horasListar.Desenvolvedor = horas.Desenvolvedor;
                horasListar.Data = horas.Data;
                horasListar.HoraInicio = horas.HoraInicio;
                horasListar.HoraFim = horas.HoraFim;

                response.Add(horasListar);
            }

            return response;
        }
    }
}
