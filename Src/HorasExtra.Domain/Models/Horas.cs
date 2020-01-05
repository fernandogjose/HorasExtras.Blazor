using System;

namespace HorasExtra.Domain.Models
{
    public class Horas
    {
        public string Id { get; set; }

        public string Desenvolvedor { get; set; }

        public DateTime Data { get; set; }

        public string HoraInicio { get; set; }

        public string HoraFim { get; set; }
    }
}
