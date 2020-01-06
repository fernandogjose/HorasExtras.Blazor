using HorasExtra.Domain.Models;
using System.Collections.Generic;

namespace HorasExtra.Domain.Interfaces.Repositories
{
    public interface IHorasRepository
    {
        Horas Obter(string id);

        List<Horas> Listar(Horas request);

        void Adicionar(Horas request);

        void Editar(Horas request);
    }
}
