using HorasExtra.Application.ViewModels;

namespace HorasExtra.Application.Interfaces
{
    public interface ILoginAppService
    {
        LoginResponseViewModel Obter(LoginRequestViewModel request);
    }
}
