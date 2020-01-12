using HorasExtra.Application.ViewModels;
using HorasExtra.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace HorasExtra.Application.Mappers
{
    public class HorasMapper
    {
        private readonly ErroMapper _erroMapper;

        public HorasMapper(ErroMapper erroMapper)
        {
            _erroMapper = erroMapper;
        }

        public Horas DeViewModelParaModel(HorasCadastrarRequestViewModel viewModel)
        {
            Horas model = new Horas
            {
                Id = viewModel.Id,
                Desenvolvedor = viewModel.Desenvolvedor,
                Data = viewModel.Data,
                HoraInicio = viewModel.HoraInicio,
                HoraFim = viewModel.HoraFim,
                Justificativa = viewModel.Justificativa
            };

            return model;
        }

        public HorasObterResponseViewModel DeModelParaViewModel(Horas model)
        {
            HorasObterResponseViewModel viewModel = new HorasObterResponseViewModel
            {
                Id = model.Id,
                Desenvolvedor = model.Desenvolvedor,
                Data = model.Data,
                HoraInicio = model.HoraInicio,
                HoraFim = model.HoraFim,
                Justificativa = model.Justificativa
            };

            return viewModel;
        }

        public List<HorasObterResponseViewModel> DeModelParaViewModel(List<Horas> model)
        {
            List<HorasObterResponseViewModel> viewModel = new List<HorasObterResponseViewModel>(0);

            foreach (var horas in model.OrderBy(x => x.Data))
            {
                viewModel.Add(DeModelParaViewModel(horas));
            }

            return viewModel;
        }
    }
}
