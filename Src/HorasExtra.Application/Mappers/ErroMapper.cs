using HorasExtra.Application.ViewModels;
using HorasExtra.Domain.Models;
using System.Collections.Generic;

namespace HorasExtra.Application.Mappers
{
    public class ErroMapper
    {
        public List<ErroViewModel> DeModelParaViewModel(List<Erro> model)
        {
            List<ErroViewModel> viewModel = new List<ErroViewModel>(0);

            if (model == null)
            {
                return viewModel;
            }

            foreach (var erro in model)
            {
                viewModel.Add(DeModelParaViewModel(erro));
            }

            return viewModel;
        }

        public ErroViewModel DeModelParaViewModel(Erro model)
        {
            ErroViewModel viewModel = new ErroViewModel
            {
                Codigo = model.Codigo,
                Descricao = model.Descricao
            };

            return viewModel;
        }
    }
}
