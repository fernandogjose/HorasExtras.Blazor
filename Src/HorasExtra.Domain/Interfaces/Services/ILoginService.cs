using HorasExtra.Domain.Models;

namespace HorasExtra.Domain.Interfaces.Services
{
    public interface ILoginService
    {
        Login Obter(Login request);
    }
}
