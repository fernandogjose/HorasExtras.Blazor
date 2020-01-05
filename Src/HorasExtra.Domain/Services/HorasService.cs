using HorasExtra.Domain.Interfaces.Repositories;
using HorasExtra.Domain.Interfaces.Services;
using HorasExtra.Domain.Models;
using System.Collections.Generic;

namespace HorasExtra.Domain.Services
{
    public class HorasService : IHorasService
    {
        private readonly IHorasRepository _horasRepository;

        public HorasService(IHorasRepository horasRepository)
        {
            _horasRepository = horasRepository;
        }

        public void Adicionar(Horas request)
        {
            _horasRepository.Adicionar(request);
        }

        public Horas Obter(string id)
        {
            Horas response = _horasRepository.Obter(id);
            return response;
        }

        public List<Horas> Listar(Horas request)
        {
            List<Horas> response = _horasRepository.Listar(request);
            return response;
        }
    }
}
