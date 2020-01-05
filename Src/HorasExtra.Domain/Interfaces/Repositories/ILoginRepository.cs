using HorasExtra.Domain.Models;
using System.Collections.Generic;

namespace HorasExtra.Domain.Interfaces.Repositories
{
    public interface ILoginRepository
    {
        Login Obter(Login request);
    }
}
