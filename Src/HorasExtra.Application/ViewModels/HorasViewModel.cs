using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HorasExtra.Application.ViewModels
{
    public class HorasCadastrarRequestViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Desenvolvedor é obrigatório")]
        public string Desenvolvedor { get; set; }

        [Required(ErrorMessage = "Data é obrigatório")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Hora inicio é obrigatório")]
        [StringLength(5, ErrorMessage = "Hora inicio inválido")]
        public string HoraInicio { get; set; }

        [Required(ErrorMessage = "Hora fim é obrigatório")]
        [StringLength(5, ErrorMessage = "Hora fim inválido")]
        public string HoraFim { get; set; }

        [Required(ErrorMessage = "Justificativa é obrigatório")]
        public string Justificativa { get; set; }
    }

    public class HorasCadastrarResponseViewModel
    {
        List<ErroViewModel> Erros { get; set; }
    }

    public class HorasObterResponseViewModel
    {
        public string Id { get; set; }

        public string Desenvolvedor { get; set; }

        public DateTime Data { get; set; }

        public string HoraInicio { get; set; }

        public string HoraFim { get; set; }

        public string Justificativa { get; set; }
    }

    public class HorasListarRequestViewModel
    {
        public string Desenvolvedor { get; set; }
    }
}
